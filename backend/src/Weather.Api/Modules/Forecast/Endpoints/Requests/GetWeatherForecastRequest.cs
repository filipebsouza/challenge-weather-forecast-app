namespace Weather.Api.Modules.Forecast.Endpoints.Requests;

public class GetWeatherForecastRequest
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public char? TemperatureUnit { get; set; }
}