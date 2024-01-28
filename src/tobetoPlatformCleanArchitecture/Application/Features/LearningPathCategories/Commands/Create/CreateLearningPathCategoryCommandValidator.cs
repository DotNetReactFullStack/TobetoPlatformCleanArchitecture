using FluentValidation;

namespace Application.Features.LearningPathCategories.Commands.Create;

public class CreateLearningPathCategoryCommandValidator : AbstractValidator<CreateLearningPathCategoryCommand>
{
    public CreateLearningPathCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.IsActive).NotEmpty();
    }
}