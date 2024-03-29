using FluentValidation;

namespace Application.Features.AnnouncementTypes.Commands.Update;

public class UpdateAnnouncementTypeCommandValidator : AbstractValidator<UpdateAnnouncementTypeCommand>
{
    public UpdateAnnouncementTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();

        RuleFor(c => c.Name).MaximumLength(25);

    }
}