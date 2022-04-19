using Core.Api.Resources.Extensions;
using Core.Api.Resources.Http.Middlewares;
using Location.Api.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
Log.Information("Starting up");

try
{
    Environment.SetEnvironmentVariable(ConfigurationProperties.LocationServiceHost,
        Environment.GetEnvironmentVariable(EnvironmentVariables.LocationServiceHost));

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.RegisterModules(typeof(Program));
    builder.Services.AddHttpClient(ConfigurationProperties.LocationServiceHttpClientName,
        c => c.BaseAddress = new Uri(builder.Configuration[ConfigurationProperties.LocationServiceHost]));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCors();

    var app = builder.Build();
    app.MapEndpoints();
    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true)
        .AllowCredentials());

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