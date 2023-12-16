using FluentValidation;

namespace Application.Features.AnnouncementTypes.Commands.Delete;

public class DeleteAnnouncementTypeCommandValidator : AbstractValidator<DeleteAnnouncementTypeCommand>
{
    public DeleteAnnouncementTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}