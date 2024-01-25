using FluentValidation;

namespace Application.Features.LearningPathCategories.Commands.Delete;

public class DeleteLearningPathCategoryCommandValidator : AbstractValidator<DeleteLearningPathCategoryCommand>
{
    public DeleteLearningPathCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}