using FluentValidation;

namespace Application.Features.ContractTypes.Commands.Create;

public class CreateContractTypeCommandValidator : AbstractValidator<CreateContractTypeCommand>
{
    public CreateContractTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.Name).MaximumLength(150);

    }
}