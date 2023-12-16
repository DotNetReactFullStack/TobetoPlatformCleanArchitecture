using FluentValidation;

namespace Application.Features.Announcements.Commands.Create;

public class CreateAnnouncementCommandValidator : AbstractValidator<CreateAnnouncementCommand>
{
    public CreateAnnouncementCommandValidator()
    {
        RuleFor(c => c.AnnouncementTypeId).NotEmpty();
        RuleFor(c => c.OrganizationId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.PublishedDate).NotEmpty();
    }
}