using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Weather.Api.Configuration;

namespace Weather.Api.Tests._Configuration;

public class MockedWebApplication : WebApplicationFactory<Program>
{
    public const string WeatherForecastServiceHost = "https://api.weather.gov/";
    
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((h, b) =>
        {
            var configurationProperties = new Dictionary<string, string>
            {
                {ConfigurationProperties.WeatherForecastServiceHost, WeatherForecastServiceHost},
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