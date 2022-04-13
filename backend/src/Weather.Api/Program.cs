using Core.Api.Resources.Extensions;
using Serilog;
using Weather.Api.Configuration;
using Weather.Api.Modules.Forecast.Endpoints;
using Weather.Api.Modules.Forecast.Ports;
using Weather.Api.Modules.Location.Adapters;
using Weather.Api.Modules.Location.Endpoints;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
Log.Information("Starting up");

try
{
    Environment.SetEnvironmentVariable(ConfigurationProperties.WeatherService,
        Environment.GetEnvironmentVariable(EnvironmentVariables.WeatherServiceHost));

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.RegisterModules(typeof(Program));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    app.MapEndpoints();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

public partial class Program
{
    // Expose the Program class for use with WebApplicationFactory<T> in Tests
}