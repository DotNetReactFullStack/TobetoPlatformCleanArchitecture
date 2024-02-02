using FluentValidation;

namespace Application.Features.GraduationStatuses.Commands.Update;

public class UpdateGraduationStatusCommandValidator : AbstractValidator<UpdateGraduationStatusCommand>
{
    public UpdateGraduationStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}