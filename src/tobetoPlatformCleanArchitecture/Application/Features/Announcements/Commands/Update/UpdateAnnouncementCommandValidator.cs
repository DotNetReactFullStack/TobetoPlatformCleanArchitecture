using FluentValidation;

namespace Application.Features.Announcements.Commands.Update;

public class UpdateAnnouncementCommandValidator : AbstractValidator<UpdateAnnouncementCommand>
{
    public UpdateAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AnnouncementTypeId).NotEmpty();
        RuleFor(c => c.OrganizationId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.PublishedDate).NotEmpty();

        RuleFor(c => c.Name).MaximumLength(100);

    }
}