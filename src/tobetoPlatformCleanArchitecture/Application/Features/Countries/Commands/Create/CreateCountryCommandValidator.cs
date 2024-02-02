using FluentValidation;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.Name).MaximumLength(30);
    }
}