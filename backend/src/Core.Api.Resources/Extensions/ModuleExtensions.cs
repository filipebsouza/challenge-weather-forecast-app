using Core.Api.Resources.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Resources.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection RegisterModules(this IServiceCollection services, Type discoveryType)
    {
        var modules = DiscoverModules(discoveryType);
        foreach (var module in modules)
        {
            module.RegisterModule(services);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var moduleServices = app.Services.GetServices<IModule>();
        foreach (var module in moduleServices)
        {
            module.MapEndpoints(app);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules(Type discoveryType)
    {
        return discoveryType.Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}