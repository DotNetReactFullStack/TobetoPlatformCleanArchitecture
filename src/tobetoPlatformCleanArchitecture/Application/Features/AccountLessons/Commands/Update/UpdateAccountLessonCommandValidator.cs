using FluentValidation;

namespace Application.Features.AccountLessons.Commands.Update;

public class UpdateAccountLessonCommandValidator : AbstractValidator<UpdateAccountLessonCommand>
{
    public UpdateAccountLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonId).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.Points).NotEmpty();
        RuleFor(c => c.IsComplete).NotEmpty();
    }
}