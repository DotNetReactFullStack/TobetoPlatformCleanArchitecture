using FluentValidation;

namespace Application.Features.Accounts.Commands.Delete;

public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}