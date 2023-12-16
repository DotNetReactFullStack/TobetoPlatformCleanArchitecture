using FluentValidation;

namespace Application.Features.AccountLearningPaths.Commands.Create;

public class CreateAccountLearningPathCommandValidator : AbstractValidator<CreateAccountLearningPathCommand>
{
    public CreateAccountLearningPathCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.PathId).NotEmpty();
        RuleFor(c => c.TotalNumberOfPoints).NotEmpty();
        RuleFor(c => c.PercentCompleted).NotEmpty();
    }
}