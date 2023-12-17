using FluentValidation;

namespace Application.Features.RecourseSteps.Commands.Delete;

public class DeleteRecourseStepCommandValidator : AbstractValidator<DeleteRecourseStepCommand>
{
    public DeleteRecourseStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}