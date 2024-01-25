using FluentValidation;

namespace Application.Features.GraduationStatus.Commands.Delete;

public class DeleteGraduationStatusCommandValidator : AbstractValidator<DeleteGraduationStatusCommand>
{
    public DeleteGraduationStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}