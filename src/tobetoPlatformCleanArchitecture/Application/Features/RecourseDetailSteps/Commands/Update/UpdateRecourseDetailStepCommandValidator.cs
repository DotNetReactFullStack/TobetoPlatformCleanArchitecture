using FluentValidation;

namespace Application.Features.RecourseDetailSteps.Commands.Update;

public class UpdateRecourseDetailStepCommandValidator : AbstractValidator<UpdateRecourseDetailStepCommand>
{
    public UpdateRecourseDetailStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(20);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}