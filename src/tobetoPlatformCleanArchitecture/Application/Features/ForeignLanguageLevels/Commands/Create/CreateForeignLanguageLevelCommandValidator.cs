using FluentValidation;

namespace Application.Features.ForeignLanguageLevels.Commands.Create;

public class CreateForeignLanguageLevelCommandValidator : AbstractValidator<CreateForeignLanguageLevelCommand>
{
    public CreateForeignLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}