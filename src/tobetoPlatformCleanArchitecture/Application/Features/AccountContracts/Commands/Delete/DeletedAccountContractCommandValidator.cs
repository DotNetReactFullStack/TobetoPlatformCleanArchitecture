using FluentValidation;

namespace Application.Features.AccountContracts.Commands.Delete;

public class DeleteAccountContractCommandValidator : AbstractValidator<DeleteAccountContractCommand>
{
    public DeleteAccountContractCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}