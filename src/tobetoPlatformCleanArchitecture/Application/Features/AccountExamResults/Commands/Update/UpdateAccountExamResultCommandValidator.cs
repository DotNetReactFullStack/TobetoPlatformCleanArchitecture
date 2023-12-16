using FluentValidation;

namespace Application.Features.AccountExamResults.Commands.Update;

public class UpdateAccountExamResultCommandValidator : AbstractValidator<UpdateAccountExamResultCommand>
{
    public UpdateAccountExamResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.NumberOfRightAnswers).NotEmpty();
        RuleFor(c => c.NumberOfWrongAnswers).NotEmpty();
        RuleFor(c => c.NumberOfNullAnswers).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
    }
}