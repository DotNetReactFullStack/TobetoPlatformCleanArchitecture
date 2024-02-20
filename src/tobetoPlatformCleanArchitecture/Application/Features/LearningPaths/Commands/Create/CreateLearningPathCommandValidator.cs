using FluentValidation;

namespace Application.Features.LearningPaths.Commands.Create;

public class CreateLearningPathCommandValidator : AbstractValidator<CreateLearningPathCommand>
{
    public CreateLearningPathCommandValidator()
    {
        RuleFor(c => c.LearningPathCategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndingTime).NotEmpty();
        RuleFor(c => c.NumberOfLikes).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.TotalDuration).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}