using FluentValidation;

namespace Application.Features.AccountCapabilities.Commands.Update;

public class UpdateAccountCapabilityCommandValidator : AbstractValidator<UpdateAccountCapabilityCommand>
{
    public UpdateAccountCapabilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CapabilityId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}