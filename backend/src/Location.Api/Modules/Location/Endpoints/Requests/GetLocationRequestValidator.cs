using FluentValidation;

namespace Location.Api.Modules.Location.Endpoints.Requests;

public class GetLocationRequestValidator : AbstractValidator<GetLocationRequest>
{
    public GetLocationRequestValidator()
    {
        RuleFor(req => req.Address)
            .NotEmpty()
            .WithMessage("'address' must not be null or empty");
    }
}