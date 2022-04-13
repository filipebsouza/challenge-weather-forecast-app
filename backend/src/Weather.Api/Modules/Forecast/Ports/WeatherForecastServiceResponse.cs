using System.Text.Json.Serialization;

namespace Weather.Api.Modules.Forecast.Ports;

public class Geometry
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("coordinates")] public List<List<List<double>>>? Coordinates { get; set; }
}

public class Elevation
{
    [JsonPropertyName("unitCode")] public string? UnitCode { get; set; }
    [JsonPropertyName("value")] public double? Value { get; set; }
}

public class Period
{
    [JsonPropertyName("number")] public int Number { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("startTime")] public DateTime StartTime { get; set; }
    [JsonPropertyName("endTime")] public DateTime EndTime { get; set; }
    [JsonPropertyName("isDaytime")] public bool IsDaytime { get; set; }
    [JsonPropertyName("temperature")] public int Temperature { get; set; }
    [JsonPropertyName("temperatureUnit")] public string? TemperatureUnit { get; set; }
    [JsonPropertyName("temperatureTrend")] public object? TemperatureTrend { get; set; }
    [JsonPropertyName("windSpeed")] public string? WindSpeed { get; set; }
    [JsonPropertyName("windDirection")] public string? WindDirection { get; set; }
    [JsonPropertyName("icon")] public string? Icon { get; set; }
    [JsonPropertyName("shortForecast")] public string? ShortForecast { get; set; }
    [JsonPropertyName("detailedForecast")] public string? DetailedForecast { get; set; }
}

public class Properties
{
    [JsonPropertyName("updated")] public DateTime Uupdated { get; set; }
    [JsonPropertyName("units")] public string? Units { get; set; }

    [JsonPropertyName("forecastGenerator")]
    public string? ForecastGenerator { get; set; }

    [JsonPropertyName("generatedAt")] public DateTime GeneratedAt { get; set; }
    [JsonPropertyName("updateTime")] public DateTime UpdateTime { get; set; }
    [JsonPropertyName("validTimes")] public string? ValidTimes { get; set; }
    [JsonPropertyName("elevation")] public Elevation? Elevation { get; set; }
    [JsonPropertyName("periods")] public List<Period>? Periods { get; set; }
}

public class WeatherForecastServiceResponse
{
    [JsonPropertyName("@context")] public List<object>? Context { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("geometry")] public Geometry? Geometry { get; set; }
    [JsonPropertyName("properties")] public Properties? Properties { get; set; }
}