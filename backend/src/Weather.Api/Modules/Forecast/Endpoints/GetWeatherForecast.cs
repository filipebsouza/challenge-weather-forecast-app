using System.Net;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.Modules.Forecast.Ports;

namespace Weather.Api.Modules.Location.Endpoints;

public static class GetWeatherForecast
{
    public static void MapGetAddress(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/forecast",
            async ([FromServices] IWeatherForecastService weatherForecastService, HttpContext context,
                [FromQuery] WeatherForecastRequest param) =>
            {
                // if (param.Latitude is null)
                // {
                //     await context.Response.WriteAsJsonAsync(new
                //     {
                //         statusCode = HttpStatusCode.BadRequest,
                //         errorMessage = "Address is empty or null"
                //     });
                //     return;
                // }

                var response = await weatherForecastService.Get(param.Latitude, param.Longitude, param.TemperatureUnit);
                await context.Response.WriteAsJsonAsync(response);
            });
    }
}

public record WeatherForecastRequest(int Latitude, int Longitude, string TemperatureUnit);
