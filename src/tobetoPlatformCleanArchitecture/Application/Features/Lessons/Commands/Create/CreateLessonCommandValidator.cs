using FluentValidation;

namespace Application.Features.Lessons.Commands.Create;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}