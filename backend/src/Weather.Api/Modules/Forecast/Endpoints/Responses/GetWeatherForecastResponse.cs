namespace Weather.Api.Modules.Location.Endpoints.Responses;

public record GetWeatherForecastResponse(GetWeatherForecastDayResponse[] Days);

public record GetWeatherForecastDayResponse(DateTime Date, string TemperatureUnit, int Temperature,
    string ShortDescription, string? Description);