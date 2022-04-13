using Core.Api.Resources.Modules;
using Location.Api.Modules.Location.Adapters;
using Location.Api.Modules.Location.Endpoints;
using Location.Api.Modules.Location.Ports;

namespace Location.Api.Modules.Location;

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