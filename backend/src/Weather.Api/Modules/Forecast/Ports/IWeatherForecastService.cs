using Weather.Api.Modules.Forecast.Endpoints.Responses;

namespace Weather.Api.Modules.Forecast.Ports;

public interface IWeatherForecastService
{
    Task<GetWeatherForecastResponse?> Get(int latitude, int longitude, char temperatureUnit);
    
}