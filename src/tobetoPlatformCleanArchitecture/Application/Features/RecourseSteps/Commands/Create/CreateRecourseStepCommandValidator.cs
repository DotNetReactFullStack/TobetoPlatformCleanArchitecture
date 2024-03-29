using FluentValidation;

namespace Application.Features.RecourseSteps.Commands.Create;

public class CreateRecourseStepCommandValidator : AbstractValidator<CreateRecourseStepCommand>
{
    public CreateRecourseStepCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(20);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}