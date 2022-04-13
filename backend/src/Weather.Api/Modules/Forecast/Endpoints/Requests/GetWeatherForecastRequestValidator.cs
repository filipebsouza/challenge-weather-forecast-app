using FluentValidation;

namespace Weather.Api.Modules.Forecast.Endpoints.Requests;

public class GetWeatherForecastRequestValidator : AbstractValidator<GetWeatherForecastRequest>
{
    public GetWeatherForecastRequestValidator()
    {
        RuleFor(req => req.Latitude)
            .NotNull()
            .WithMessage("'latitude' must not be null");
        
        RuleFor(req => req.Longitude)
            .NotNull()
            .WithMessage("'longitude' must not be null");
        
        RuleFor(req => req.TemperatureUnit)
            .NotNull()
            .WithMessage("'temperatureUnit' must not be null")
            .Must(temperatureUnit => temperatureUnit != 'C' && temperatureUnit != 'F')
            .WithMessage("'temperatureUnit' must be equals to C or F");
    }
}