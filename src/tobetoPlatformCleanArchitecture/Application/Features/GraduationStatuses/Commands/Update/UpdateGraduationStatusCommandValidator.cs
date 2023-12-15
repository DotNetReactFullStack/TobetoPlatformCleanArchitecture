using FluentValidation;

namespace Application.Features.GraduationStatuses.Commands.Update;

public class UpdateGraduationStatusCommandValidator : AbstractValidator<UpdateGraduationStatusCommand>
{
    public UpdateGraduationStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}