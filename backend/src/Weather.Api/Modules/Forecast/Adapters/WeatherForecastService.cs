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

    public async Task<GetWeatherForecastResponse?> Get(int latitude, int longitude, char temperatureUnit)
    {
        var response =
            await _httpClient.GetAsync(
                $"{longitude},{latitude}/forecast?units={(temperatureUnit == 'C' ? "si" : "us")}");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Weather forecast not found");
            return null;
        }

        var data = await response.ReadAsResponseDtoAsync<WeatherForecastServiceResponse>();
        if (data is null || data.Properties is null)
        {
            _logger.LogInformation($"Json parse error from {nameof(WeatherForecastService)}");
            return null;
        }

        var days = data?.Properties?.Periods
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