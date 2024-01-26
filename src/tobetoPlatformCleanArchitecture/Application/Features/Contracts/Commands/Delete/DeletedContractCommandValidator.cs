using FluentValidation;

namespace Application.Features.Contracts.Commands.Delete;

public class DeleteContractCommandValidator : AbstractValidator<DeleteContractCommand>
{
    public DeleteContractCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}