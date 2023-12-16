using FluentValidation;

namespace Application.Features.AccountCourses.Commands.Delete;

public class DeleteAccountCourseCommandValidator : AbstractValidator<DeleteAccountCourseCommand>
{
    public DeleteAccountCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}