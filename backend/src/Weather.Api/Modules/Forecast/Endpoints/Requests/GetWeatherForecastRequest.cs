namespace Weather.Api.Modules.Forecast.Endpoints.Requests;

public class GetWeatherForecastRequest
{
    public int? Latitude { get; set; }
    public int? Longitude { get; set; }
    public char? TemperatureUnit { get; set; }
}