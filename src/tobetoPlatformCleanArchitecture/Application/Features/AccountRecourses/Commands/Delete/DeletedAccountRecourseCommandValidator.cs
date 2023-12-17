using FluentValidation;

namespace Application.Features.AccountRecourses.Commands.Delete;

public class DeleteAccountRecourseCommandValidator : AbstractValidator<DeleteAccountRecourseCommand>
{
    public DeleteAccountRecourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}