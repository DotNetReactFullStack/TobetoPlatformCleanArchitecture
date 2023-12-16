using FluentValidation;

namespace Application.Features.CourseLearningPaths.Commands.Create;

public class CreateCourseLearningPathCommandValidator : AbstractValidator<CreateCourseLearningPathCommand>
{
    public CreateCourseLearningPathCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.PathId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}