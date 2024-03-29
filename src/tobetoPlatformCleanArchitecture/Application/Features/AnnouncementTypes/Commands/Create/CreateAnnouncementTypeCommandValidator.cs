using FluentValidation;

namespace Application.Features.AnnouncementTypes.Commands.Create;

public class CreateAnnouncementTypeCommandValidator : AbstractValidator<CreateAnnouncementTypeCommand>
{
    public CreateAnnouncementTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();

        RuleFor(c => c.Name).MaximumLength(25);

    }
}