using FluentValidation;

namespace Application.Features.ContractTypes.Commands.Delete;

public class DeleteContractTypeCommandValidator : AbstractValidator<DeleteContractTypeCommand>
{
    public DeleteContractTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}