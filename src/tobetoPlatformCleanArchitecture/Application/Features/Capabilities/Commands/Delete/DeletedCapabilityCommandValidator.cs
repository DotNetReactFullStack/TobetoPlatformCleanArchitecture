using FluentValidation;

namespace Application.Features.Capabilities.Commands.Delete;

public class DeleteCapabilityCommandValidator : AbstractValidator<DeleteCapabilityCommand>
{
    public DeleteCapabilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}