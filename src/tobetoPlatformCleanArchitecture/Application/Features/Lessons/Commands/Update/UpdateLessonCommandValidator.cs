using FluentValidation;

namespace Application.Features.Lessons.Commands.Update;

public class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommand>
{
    public UpdateLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Language).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Content).NotEmpty().MaximumLength(300);
        RuleFor(c => c.Duration).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.IsActive).NotEmpty();
    }
}