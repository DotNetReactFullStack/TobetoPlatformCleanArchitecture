using FluentValidation;

namespace Application.Features.AccountCapabilities.Commands.Delete;

public class DeleteAccountCapabilityCommandValidator : AbstractValidator<DeleteAccountCapabilityCommand>
{
    public DeleteAccountCapabilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}