using FluentValidation;

namespace Application.Features.AccountLearningPaths.Commands.Create;

public class CreateAccountLearningPathCommandValidator : AbstractValidator<CreateAccountLearningPathCommand>
{
    public CreateAccountLearningPathCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.LearningPathId).NotEmpty();
        RuleFor(c => c.TotalNumberOfPoints).NotEmpty();
        RuleFor(c => c.PercentComplete).NotEmpty();
        RuleFor(c => c.IsContinue).NotEmpty();
        RuleFor(c => c.IsComplete).NotEmpty();
        RuleFor(c => c.IsLiked).NotEmpty();
        RuleFor(c => c.IsSaved).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}