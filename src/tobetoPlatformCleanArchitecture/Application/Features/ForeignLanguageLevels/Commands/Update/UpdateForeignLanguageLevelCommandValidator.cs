using FluentValidation;

namespace Application.Features.ForeignLanguageLevels.Commands.Update;

public class UpdateForeignLanguageLevelCommandValidator : AbstractValidator<UpdateForeignLanguageLevelCommand>
{
    public UpdateForeignLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}