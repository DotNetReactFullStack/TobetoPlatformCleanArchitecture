using FluentValidation;

namespace Application.Features.AccountAnnouncements.Commands.Create;

public class CreateAccountAnnouncementCommandValidator : AbstractValidator<CreateAccountAnnouncementCommand>
{
    public CreateAccountAnnouncementCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.AnnouncementId).NotEmpty();
        RuleFor(c => c.Read).NotEmpty();
    }
}