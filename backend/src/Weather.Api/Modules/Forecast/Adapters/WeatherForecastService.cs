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

        var weatherResponse =
            await _httpClient.GetAsync(
                $"{preciseLocationData.Properties!.Forecast!}?units={(temperatureUnit == 'C' ? "si" : "us")}");
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

        var days = forecastData?.Properties?.Periods
            ?.Select(period => new GetWeatherForecastDayResponse
            {
                Date = period.StartTime,
                TemperatureUnit = period.TemperatureUnit!,
                Temperature = period.Temperature,
                ShortDescription = period.ShortForecast!,
                Description = period.DetailedForecast
            }).ToArray();

        if (days is null)
        {
            _logger.LogInformation("Invalid forecast!");
            return null;
        }

        return new GetWeatherForecastResponse
        {
            Days = days
        };
    }
}