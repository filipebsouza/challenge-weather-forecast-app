namespace Weather.Api.Features;

public static class GetAddress
{
    public static void MapGetAddress(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapGet("/location/address", () =>
        {
            
        });
    }
}