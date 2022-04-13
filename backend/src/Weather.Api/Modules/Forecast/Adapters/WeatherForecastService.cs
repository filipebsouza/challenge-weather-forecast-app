using Core.Api.Resources.Extensions;
using Weather.Api.Configuration;
using Weather.Api.Modules.Forecast.Ports;
using Weather.Api.Modules.Location.Endpoints.Responses;

namespace Weather.Api.Modules.Location.Adapters;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly HttpClient _httpClient;

    public WeatherForecastService(ILogger<WeatherForecastService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(configuration[ConfigurationProperties.LocationService]);
    }

    public async Task<GetWeatherForecastResponse?> Get(int latitude, int longitude, string temperatureUnit)
    {
        var response =
            await _httpClient.GetAsync(
                $"{longitude}{latitude}/forecast?units={(temperatureUnit.ToUpper() == "C" ? "si" : "us")}");
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogInformation("Weather forecast not found");
            return null;
        }

        var data = await response.ReadAsResponseDtoAsync<WeatherForecastServiceResponse>();
        if (data is null) return null;

        var days = data?.Properties?.Periods
            ?.Select(period => new GetWeatherForecastDayResponse(period.StartTime, period.TemperatureUnit!,
                period.Temperature, period.ShortForecast!, period.DetailedForecast)).ToArray();

        if (days is null) return null;

        return new GetWeatherForecastResponse(days);
    }
}