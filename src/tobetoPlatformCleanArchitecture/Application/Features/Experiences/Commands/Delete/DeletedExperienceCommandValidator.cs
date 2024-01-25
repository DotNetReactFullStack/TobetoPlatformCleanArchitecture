using FluentValidation;

namespace Application.Features.Experiences.Commands.Delete;

public class DeleteExperienceCommandValidator : AbstractValidator<DeleteExperienceCommand>
{
    public DeleteExperienceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}