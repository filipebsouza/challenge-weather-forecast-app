using System.Net;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.Infrastructure;

namespace Weather.Api.Features;

public static class GetAddress
{
    public static void MapGetAddress(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/location",
            async ([FromServices] ILocationService locationService, HttpContext context, string? address) =>
            {
                if (address is null)
                {
                    await context.Response.WriteAsJsonAsync(new
                    {
                        statusCode = HttpStatusCode.BadRequest,
                        errorMessage = "Address is empty or null"
                    });
                    return;
                }

                var response = await locationService.Get(address);
                await context.Response.WriteAsJsonAsync(response);
            });
    }
}