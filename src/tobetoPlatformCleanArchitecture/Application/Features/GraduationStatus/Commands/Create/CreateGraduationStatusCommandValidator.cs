using FluentValidation;

namespace Application.Features.GraduationStatus.Commands.Create;

public class CreateGraduationStatusCommandValidator : AbstractValidator<CreateGraduationStatusCommand>
{
    public CreateGraduationStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}