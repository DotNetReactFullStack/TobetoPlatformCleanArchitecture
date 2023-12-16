using FluentValidation;

namespace Application.Features.AccountLearningPaths.Commands.Delete;

public class DeleteAccountLearningPathCommandValidator : AbstractValidator<DeleteAccountLearningPathCommand>
{
    public DeleteAccountLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}