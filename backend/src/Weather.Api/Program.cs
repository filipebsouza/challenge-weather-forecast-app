using Serilog;
using Weather.Api.Configuration;
using Weather.Api.Features;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
Log.Information("Starting up");

try
{
    Environment.SetEnvironmentVariable(ConfigurationProperties.LocationService,
        Environment.GetEnvironmentVariable(EnvironmentVariables.LocationServiceHost));
    Environment.SetEnvironmentVariable(ConfigurationProperties.WeatherService,
        Environment.GetEnvironmentVariable(EnvironmentVariables.WeatherServiceHost));

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapGetAddress();

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