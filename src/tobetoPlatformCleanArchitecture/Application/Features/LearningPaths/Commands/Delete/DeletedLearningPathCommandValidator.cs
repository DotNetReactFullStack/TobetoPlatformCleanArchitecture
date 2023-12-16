using FluentValidation;

namespace Application.Features.LearningPaths.Commands.Delete;

public class DeleteLearningPathCommandValidator : AbstractValidator<DeleteLearningPathCommand>
{
    public DeleteLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}