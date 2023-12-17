using FluentValidation;

namespace Application.Features.RecourseSteps.Commands.Create;

public class CreateRecourseStepCommandValidator : AbstractValidator<CreateRecourseStepCommand>
{
    public CreateRecourseStepCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}