namespace Weather.Api.Modules.Forecast.Endpoints.Responses;

public record GetWeatherForecastResponse(GetWeatherForecastDayResponse[] Days);

public record GetWeatherForecastDayResponse(DateTime Date, string TemperatureUnit, int Temperature,
    string ShortDescription, string? Description);