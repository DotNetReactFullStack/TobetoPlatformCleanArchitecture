using FluentValidation;

namespace Application.Features.Districts.Commands.Update;

public class UpdateDistrictCommandValidator : AbstractValidator<UpdateDistrictCommand>
{
    public UpdateDistrictCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}