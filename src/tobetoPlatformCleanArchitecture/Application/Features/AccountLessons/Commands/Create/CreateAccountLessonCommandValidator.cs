using FluentValidation;

namespace Application.Features.AccountLessons.Commands.Create;

public class CreateAccountLessonCommandValidator : AbstractValidator<CreateAccountLessonCommand>
{
    public CreateAccountLessonCommandValidator()
    {
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
        RuleFor(c => c.IsComplete).NotEmpty();
    }
}