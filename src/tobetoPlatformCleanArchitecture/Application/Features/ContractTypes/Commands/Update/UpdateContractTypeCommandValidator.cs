using FluentValidation;

namespace Application.Features.ContractTypes.Commands.Update;

public class UpdateContractTypeCommandValidator : AbstractValidator<UpdateContractTypeCommand>
{
    public UpdateContractTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.Name).MaximumLength(150);

    }
}