using Core.Api.Resources.Extensions;
using Core.Api.Resources.Http.Middlewares;
using Serilog;
using Weather.Api.Configuration;

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

    app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
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