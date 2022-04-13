using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Weather.Api.Configuration;

namespace Weather.Api.Tests._Configuration;

public class MockedWebApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((h, b) =>
        {
            var configurationProperties = new Dictionary<string, string>
            {
                {ConfigurationProperties.WeatherService, "https://api.weather.gov/gridpoints/LWX/"},
            };
            b.AddInMemoryCollection(configurationProperties);
        });
        
        return base.CreateHost(builder);
    }
}

public static class MockedWebApplicationSingleton
{
    public static MockedWebApplication Instance => new();
}