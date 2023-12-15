using FluentValidation;

namespace Application.Features.ForeignLanguageLevels.Commands.Delete;

public class DeleteForeignLanguageLevelCommandValidator : AbstractValidator<DeleteForeignLanguageLevelCommand>
{
    public DeleteForeignLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}