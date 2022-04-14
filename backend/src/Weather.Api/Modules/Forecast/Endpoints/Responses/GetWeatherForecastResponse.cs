using System.Text.Json.Serialization;

namespace Weather.Api.Modules.Forecast.Endpoints.Responses;

public class GetWeatherForecastResponse
{
    [JsonPropertyName("days")]
    public GetWeatherForecastDayResponse[] Days { get; set; } = null!;
}

public class GetWeatherForecastDayResponse
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }
    [JsonPropertyName("temperatureUnit")]
    public string TemperatureUnit { get; set; } = null!;
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; }
    [JsonPropertyName("shortDescription")]
    public string ShortDescription { get; set; } = null!;
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}