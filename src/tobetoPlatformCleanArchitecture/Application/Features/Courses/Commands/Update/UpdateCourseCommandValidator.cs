using FluentValidation;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.TotalDuration).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}