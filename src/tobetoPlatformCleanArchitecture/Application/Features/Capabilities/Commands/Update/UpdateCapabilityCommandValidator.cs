using FluentValidation;

namespace Application.Features.Capabilities.Commands.Update;

public class UpdateCapabilityCommandValidator : AbstractValidator<UpdateCapabilityCommand>
{
    public UpdateCapabilityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();

        RuleFor(c => c.Name).MaximumLength(30);

    }
}