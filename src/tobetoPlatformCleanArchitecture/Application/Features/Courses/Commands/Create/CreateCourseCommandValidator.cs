using FluentValidation;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.CourseCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.TotalDuration).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.Name).MaximumLength(50);
        RuleFor(c => c.TotalDuration).GreaterThanOrEqualTo(0);
    }
}