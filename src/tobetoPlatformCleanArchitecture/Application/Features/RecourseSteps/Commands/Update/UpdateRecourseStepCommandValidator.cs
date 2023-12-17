using FluentValidation;

namespace Application.Features.RecourseSteps.Commands.Update;

public class UpdateRecourseStepCommandValidator : AbstractValidator<UpdateRecourseStepCommand>
{
    public UpdateRecourseStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}