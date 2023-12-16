using FluentValidation;

namespace Application.Features.CourseLearningPaths.Commands.Update;

public class UpdateCourseLearningPathCommandValidator : AbstractValidator<UpdateCourseLearningPathCommand>
{
    public UpdateCourseLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.PathId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}