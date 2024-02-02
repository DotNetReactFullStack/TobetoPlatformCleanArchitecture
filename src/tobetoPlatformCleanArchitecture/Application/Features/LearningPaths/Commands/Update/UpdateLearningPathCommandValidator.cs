using FluentValidation;

namespace Application.Features.LearningPaths.Commands.Update;

public class UpdateLearningPathCommandValidator : AbstractValidator<UpdateLearningPathCommand>
{
    public UpdateLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LearningPathCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndingTime).NotEmpty();
        RuleFor(c => c.NumberOfLikes).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.TotalDuration).NotEmpty().GreaterThanOrEqualTo(0);
    }
}