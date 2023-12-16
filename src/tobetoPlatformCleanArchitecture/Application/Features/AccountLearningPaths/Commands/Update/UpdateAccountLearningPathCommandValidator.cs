using FluentValidation;

namespace Application.Features.AccountLearningPaths.Commands.Update;

public class UpdateAccountLearningPathCommandValidator : AbstractValidator<UpdateAccountLearningPathCommand>
{
    public UpdateAccountLearningPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.PathId).NotEmpty();
        RuleFor(c => c.TotalNumberOfPoints).NotEmpty();
        RuleFor(c => c.PercentCompleted).NotEmpty();
    }
}