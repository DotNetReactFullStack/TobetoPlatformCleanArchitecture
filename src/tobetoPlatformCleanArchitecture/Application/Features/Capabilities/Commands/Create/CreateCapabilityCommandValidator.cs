using FluentValidation;

namespace Application.Features.Capabilities.Commands.Create;

public class CreateCapabilityCommandValidator : AbstractValidator<CreateCapabilityCommand>
{
    public CreateCapabilityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}