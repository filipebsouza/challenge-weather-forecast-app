using Core.Api.Resources.Extensions;
using Weather.Api.Configuration;
using Weather.Api.Modules.Forecast.Endpoints.Responses;
using Weather.Api.Modules.Forecast.Ports;

namespace Weather.Api.Modules.Forecast.Adapters;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly HttpClient _httpClient;

    public WeatherForecastService(ILogger<WeatherForecastService> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _httpClient = factory.CreateClient(ConfigurationProperties.WeatherForecastServiceHttpClientName);
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("(filipe.dev, filipe.bsouza@gmail.com)");
    }

    public async Task<GetWeatherForecastResponse?> Get(double latitude, double longitude, char temperatureUnit)
    {
        var preciseLocationData = await GetPreciseLocation(latitude, longitude);
        if (preciseLocationData is null) return null;

        var forecastData = await GetWeatherForecast(preciseLocationData.Properties!.Forecast!, temperatureUnit);
        if (forecastData is null) return null;

        return ConvertToResponse(forecastData);
    }

    private GetWeatherForecastResponse? ConvertToResponse(WeatherForecastServiceResponse? forecastData)
    {
        var periods = forecastData?.Properties?.Periods;
        if (periods is null) return null;

        var days = periods.Select(period => new GetWeatherForecastDayResponse
            {
                Date = period.StartTime,
                TemperatureUnit = period.TemperatureUnit!,
                Temperature = period.Temperature,
                ShortDescription = period.ShortForecast!,
                Image = period.Icon,
                Description = period.DetailedForecast,
                IsDayTime = period.IsDaytime
            }).ToArray();
        if (days.Length == 0)
        {
            _logger.LogInformation("Invalid forecast!");
            return null;
        }
        
        return new GetWeatherForecastResponse
        {
            Days = days
        };
    }

    private async Task<WeatherForecastServiceResponse?> GetWeatherForecast(string resourceUri, char temperatureUnit)
    {
        var weatherResponse = await _httpClient.GetAsync(
            $"{resourceUri}?units={(temperatureUnit == 'C' ? "si" : "us")}");
        if (!weatherResponse.IsSuccessStatusCode)
        {
            _logger.LogInformation("Weather forecast not found");
            return null;
        }

        var forecastData = await weatherResponse.ReadAsResponseDtoAsync<WeatherForecastServiceResponse>();
        if (forecastData is null || forecastData.Properties is null)
        {
            _logger.LogInformation($"Json parse error to {nameof(WeatherForecastServiceResponse)}");
            return null;
        }

        return forecastData;
    }

    private async Task<WeatherPreciseLocationResponse?> GetPreciseLocation(double latitude, double longitude)
    {
        var weatherPreciseLocationResponse = await _httpClient.GetAsync($"points/{latitude},{longitude}");
        if (!weatherPreciseLocationResponse.IsSuccessStatusCode)
        {
            _logger.LogInformation("Weather precise location not found");
            return null;
        }

        var preciseLocationData =
            await weatherPreciseLocationResponse.ReadAsResponseDtoAsync<WeatherPreciseLocationResponse>();
        if (preciseLocationData is null || preciseLocationData?.Properties?.Forecast is null)
        {
            _logger.LogInformation($"Json parse error to {nameof(WeatherPreciseLocationResponse)}");
            return null;
        }

        return preciseLocationData;
    }
}