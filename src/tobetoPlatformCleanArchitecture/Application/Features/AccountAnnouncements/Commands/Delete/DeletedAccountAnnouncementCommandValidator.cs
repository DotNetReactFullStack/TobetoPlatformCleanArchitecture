using FluentValidation;

namespace Application.Features.AccountAnnouncements.Commands.Delete;

public class DeleteAccountAnnouncementCommandValidator : AbstractValidator<DeleteAccountAnnouncementCommand>
{
    public DeleteAccountAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}