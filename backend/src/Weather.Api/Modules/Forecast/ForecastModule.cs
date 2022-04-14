using Core.Api.Resources.Modules;
using Weather.Api.Modules.Forecast.Adapters;
using Weather.Api.Modules.Forecast.Endpoints;
using Weather.Api.Modules.Forecast.Ports;

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
        endpoints.MapGet("/forecast", new GetWeatherForecast().Map);
        return endpoints;
    }
}