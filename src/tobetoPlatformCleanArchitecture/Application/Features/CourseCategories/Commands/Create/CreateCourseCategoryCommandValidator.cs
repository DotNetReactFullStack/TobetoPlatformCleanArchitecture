using FluentValidation;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreateCourseCategoryCommandValidator : AbstractValidator<CreateCourseCategoryCommand>
{
    public CreateCourseCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}