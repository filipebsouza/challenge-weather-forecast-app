using System.Net;
using Location.Api.Modules.Location.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Location.Api.Modules.Location.Endpoints;

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