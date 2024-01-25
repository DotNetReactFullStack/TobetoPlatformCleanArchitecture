using FluentValidation;

namespace Application.Features.LearningPathCategories.Commands.Create;

public class CreateLearningPathCategoryCommandValidator : AbstractValidator<CreateLearningPathCategoryCommand>
{
    public CreateLearningPathCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}