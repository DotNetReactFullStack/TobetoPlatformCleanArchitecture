using FluentValidation;

namespace Application.Features.Contracts.Commands.Create;

public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor(c => c.ContractTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Path).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.Name).MaximumLength(150);

    }
}