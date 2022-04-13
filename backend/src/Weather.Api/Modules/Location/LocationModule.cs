using Core.Api.Resources.Modules;
using Weather.Api.Modules.Location.Adapters;
using Weather.Api.Modules.Location.Endpoints;
using Weather.Api.Modules.Location.Ports;

namespace Weather.Api.Modules.Location;

public class LocationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddTransient<ILocationService, LocationService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGetAddress();
        return endpoints;
    }
}