using FluentValidation;

namespace Application.Features.AccountRecourseDetails.Commands.Delete;

public class DeleteAccountRecourseDetailCommandValidator : AbstractValidator<DeleteAccountRecourseDetailCommand>
{
    public DeleteAccountRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}