using FluentValidation;

namespace Application.Features.AccountContracts.Commands.Create;

public class CreateAccountContractCommandValidator : AbstractValidator<CreateAccountContractCommand>
{
    public CreateAccountContractCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ContractId).NotEmpty();
        RuleFor(c => c.IsAccept).NotEmpty();
    }
}