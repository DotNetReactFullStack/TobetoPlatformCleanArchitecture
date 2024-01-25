using FluentValidation;

namespace Application.Features.RecourseDetailSteps.Commands.Delete;

public class DeleteRecourseDetailStepCommandValidator : AbstractValidator<DeleteRecourseDetailStepCommand>
{
    public DeleteRecourseDetailStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}