using Core.Api.Resources.Modules;
using Weather.Api.Modules.Forecast.Ports;
using Weather.Api.Modules.Location.Adapters;
using Weather.Api.Modules.Location.Endpoints;

namespace Weather.Api.Modules.Forecast;

public class ForecastModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGetAddress();
        return endpoints;
    }
}