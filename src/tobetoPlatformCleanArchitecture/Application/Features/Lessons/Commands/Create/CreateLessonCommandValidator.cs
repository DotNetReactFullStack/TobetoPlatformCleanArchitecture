using FluentValidation;

namespace Application.Features.Lessons.Commands.Create;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Language).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Content).NotEmpty().MaximumLength(300);
        RuleFor(c => c.Duration).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => c.VideoUrl).NotEmpty();
    }
}