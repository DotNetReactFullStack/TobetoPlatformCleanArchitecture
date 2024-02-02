using FluentValidation;

namespace Application.Features.Contracts.Commands.Update;

public class UpdateContractCommandValidator : AbstractValidator<UpdateContractCommand>
{
    public UpdateContractCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ContractTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Path).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.Name).MaximumLength(150);

    }
}