using Weather.Api.Modules.Location.Endpoints.Responses;

namespace Weather.Api.Modules.Forecast.Ports;

public interface IWeatherForecastService
{
    Task<GetWeatherForecastResponse?> Get(int paramLatitude, int paramLongitude, string paramTemperatureUnit);
    
}