using FluentValidation;

namespace Application.Features.LearningPathCategories.Commands.Update;

public class UpdateLearningPathCategoryCommandValidator : AbstractValidator<UpdateLearningPathCategoryCommand>
{
    public UpdateLearningPathCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.IsActive).NotEmpty();
    }
}