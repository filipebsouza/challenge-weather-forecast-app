using Core.Api.Resources.Extensions;
using Location.Api.Modules.Location.Endpoints.Requests;
using Location.Api.Modules.Location.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Location.Api.Modules.Location.Endpoints;

public class GetLocation
{
    private readonly GetLocationRequestValidator _validator = new();
    
    public async Task Map([FromServices] ILocationService locationService, HttpContext context, string? address)
    {
        var request = new GetLocationRequest {Address = address};
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            await context.Response.WriteValidationErrorsAsync(validationResult.Errors);
            return;
        }

        var response = await locationService.Get(request.Address!);
        if (response is null)
        {
            await context.Response.WriteBadRequestAsync("Unexpected error during getting location");
            return;
        }

        await context.Response.WriteAsJsonAsync(response);
    }
}