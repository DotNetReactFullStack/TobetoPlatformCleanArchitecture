using FluentValidation;

namespace Application.Features.AccountAnnouncements.Commands.Update;

public class UpdateAccountAnnouncementCommandValidator : AbstractValidator<UpdateAccountAnnouncementCommand>
{
    public UpdateAccountAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.AnnouncementId).NotEmpty();
        RuleFor(c => c.Read).NotEmpty();
    }
}