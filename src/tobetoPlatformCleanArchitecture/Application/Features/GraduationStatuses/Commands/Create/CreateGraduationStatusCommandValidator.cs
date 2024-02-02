using FluentValidation;

namespace Application.Features.GraduationStatuses.Commands.Create;

public class CreateGraduationStatusCommandValidator : AbstractValidator<CreateGraduationStatusCommand>
{
    public CreateGraduationStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}