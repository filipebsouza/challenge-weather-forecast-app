using System.Collections.Generic;
using Location.Api.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Location.Api.Tests._Configuration;

public class MockedWebApplication : WebApplicationFactory<Program>
{
    public const string LocationServiceHost = "https://geocoding.geo.census.gov/geocoder/locations/";
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((h, b) =>
        {
            var configurationProperties = new Dictionary<string, string>
            {
                {ConfigurationProperties.LocationServiceHost, LocationServiceHost},
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