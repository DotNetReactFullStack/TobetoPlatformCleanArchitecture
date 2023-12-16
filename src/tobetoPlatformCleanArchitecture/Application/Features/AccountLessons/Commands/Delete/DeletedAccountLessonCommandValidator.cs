using FluentValidation;

namespace Application.Features.AccountLessons.Commands.Delete;

public class DeleteAccountLessonCommandValidator : AbstractValidator<DeleteAccountLessonCommand>
{
    public DeleteAccountLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}