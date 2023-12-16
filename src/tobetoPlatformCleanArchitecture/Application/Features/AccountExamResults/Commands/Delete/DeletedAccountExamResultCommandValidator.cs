using FluentValidation;

namespace Application.Features.AccountExamResults.Commands.Delete;

public class DeleteAccountExamResultCommandValidator : AbstractValidator<DeleteAccountExamResultCommand>
{
    public DeleteAccountExamResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}