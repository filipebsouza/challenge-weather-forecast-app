using Weather.Api.Modules.Forecast.Endpoints.Responses;

namespace Weather.Api.Modules.Forecast.Ports;

public interface IWeatherForecastService
{
    Task<GetWeatherForecastResponse?> Get(double latitude, double longitude, char temperatureUnit);
}