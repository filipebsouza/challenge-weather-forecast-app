using Core.Api.Resources.Extensions;
using Weather.Api.Configuration;
using Weather.Api.Modules.Forecast.Endpoints.Responses;
using Weather.Api.Modules.Forecast.Ports;

namespace Weather.Api.Modules.Location.Adapters;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly ILogger<WeatherForecastService> _logger;
    private readonly HttpClient _httpClient;

    public WeatherForecastService(ILogger<WeatherForecastService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(configuration[ConfigurationProperties.WeatherService]);
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
            var error = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Error: {error}");
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