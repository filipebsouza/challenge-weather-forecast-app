using Core.Api.Resources.Extensions;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.Modules.Forecast.Endpoints.Requests;
using Weather.Api.Modules.Forecast.Ports;

namespace Weather.Api.Modules.Forecast.Endpoints;

public class GetWeatherForecast
{
    private readonly GetWeatherForecastRequestValidator _validator;

    public GetWeatherForecast()
    {
        _validator = new GetWeatherForecastRequestValidator();
    }
    
    public async Task Map([FromServices] IWeatherForecastService weatherForecastService, HttpContext context,
        int? latitude, int? longitude, char? temperatureUnit)
    {
        var request = new GetWeatherForecastRequest
            {Latitude = latitude, Longitude = longitude, TemperatureUnit = temperatureUnit};

        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            await context.Response.WriteValidationErrorsAsync(validationResult.Errors);
            return;
        } 
        
        var response = await weatherForecastService.Get(request.Latitude!.Value, request.Longitude!.Value,
            request.TemperatureUnit!.Value);
        
        await context.Response.WriteAsJsonAsync(response);
    }
}