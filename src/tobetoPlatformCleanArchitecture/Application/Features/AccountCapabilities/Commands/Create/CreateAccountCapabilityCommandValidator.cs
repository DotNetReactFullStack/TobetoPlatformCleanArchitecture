using FluentValidation;

namespace Application.Features.AccountCapabilities.Commands.Create;

public class CreateAccountCapabilityCommandValidator : AbstractValidator<CreateAccountCapabilityCommand>
{
    public CreateAccountCapabilityCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CapabilityId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}