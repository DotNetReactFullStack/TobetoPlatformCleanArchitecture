using FluentValidation;

namespace Application.Features.RecourseDetailSteps.Commands.Create;

public class CreateRecourseDetailStepCommandValidator : AbstractValidator<CreateRecourseDetailStepCommand>
{
    public CreateRecourseDetailStepCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(20);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}