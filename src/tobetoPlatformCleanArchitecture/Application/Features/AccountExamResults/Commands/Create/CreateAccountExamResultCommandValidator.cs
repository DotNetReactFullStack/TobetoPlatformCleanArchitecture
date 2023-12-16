using FluentValidation;

namespace Application.Features.AccountExamResults.Commands.Create;

public class CreateAccountExamResultCommandValidator : AbstractValidator<CreateAccountExamResultCommand>
{
    public CreateAccountExamResultCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.NumberOfRightAnswers).NotEmpty();
        RuleFor(c => c.NumberOfWrongAnswers).NotEmpty();
        RuleFor(c => c.NumberOfNullAnswers).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
    }
}