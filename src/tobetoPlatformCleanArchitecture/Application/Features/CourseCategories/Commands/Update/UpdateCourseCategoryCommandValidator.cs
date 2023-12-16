using FluentValidation;

namespace Application.Features.CourseCategories.Commands.Update;

public class UpdateCourseCategoryCommandValidator : AbstractValidator<UpdateCourseCategoryCommand>
{
    public UpdateCourseCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}