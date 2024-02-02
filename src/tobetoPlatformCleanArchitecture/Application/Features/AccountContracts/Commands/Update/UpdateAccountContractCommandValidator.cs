using FluentValidation;

namespace Application.Features.AccountContracts.Commands.Update;

public class UpdateAccountContractCommandValidator : AbstractValidator<UpdateAccountContractCommand>
{
    public UpdateAccountContractCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ContractId).NotEmpty();
        RuleFor(c => c.IsAccept).NotNull();
    }
}