using Microsoft.AspNetCore.Mvc;
using Weather.Api.Modules.Forecast.Ports;

namespace Weather.Api.Modules.Forecast.Endpoints;

public class GetWeatherForecast
{
    public async Task Map([FromServices] IWeatherForecastService weatherForecastService, HttpContext context,
        int? latitude, int? longitude, string? temperatureUnit)
    {
        var response = await weatherForecastService.Get(latitude!.Value, longitude!.Value,
            temperatureUnit!);
        await context.Response.WriteAsJsonAsync(response);
    }
}