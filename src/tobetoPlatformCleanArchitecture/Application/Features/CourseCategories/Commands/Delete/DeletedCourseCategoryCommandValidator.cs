using FluentValidation;

namespace Application.Features.CourseCategories.Commands.Delete;

public class DeleteCourseCategoryCommandValidator : AbstractValidator<DeleteCourseCategoryCommand>
{
    public DeleteCourseCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}