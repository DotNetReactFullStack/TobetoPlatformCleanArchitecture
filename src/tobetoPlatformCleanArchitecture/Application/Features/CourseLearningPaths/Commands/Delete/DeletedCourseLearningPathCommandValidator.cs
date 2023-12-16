using FluentValidation;

namespace Application.Features.CourseLearningPaths.Commands.Delete;

public class DeleteCourseLearningPathCommandValidator : AbstractValidator<DeleteCourseLearningPathCommand>
{
    public DeleteCourseLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}