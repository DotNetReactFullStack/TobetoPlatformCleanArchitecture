using FluentValidation;

namespace Application.Features.ForeignLanguages.Commands.Delete;

public class DeleteForeignLanguageCommandValidator : AbstractValidator<DeleteForeignLanguageCommand>
{
    public DeleteForeignLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}