using FluentValidation;

namespace Application.Features.AccountLearningPaths.Commands.Update;

public class UpdateAccountLearningPathCommandValidator : AbstractValidator<UpdateAccountLearningPathCommand>
{
    public UpdateAccountLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.LearningPathId).NotEmpty();
        RuleFor(c => c.TotalNumberOfPoints).NotEmpty();
        RuleFor(c => c.PercentComplete).NotEmpty();
        RuleFor(c => c.IsContinue).NotNull();
        RuleFor(c => c.IsComplete).NotNull();
        RuleFor(c => c.IsLiked).NotNull();
        RuleFor(c => c.IsSaved).NotNull();
        RuleFor(c => c.IsActive).NotNull();

        RuleFor(c => c.TotalNumberOfPoints).GreaterThanOrEqualTo(0);
        RuleFor(c => (int)c.PercentComplete).LessThanOrEqualTo(100);
    }
}