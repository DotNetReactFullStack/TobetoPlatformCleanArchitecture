using FluentValidation;

namespace Application.Features.Colleges.Commands.Update;

public class UpdateCollegeCommandValidator : AbstractValidator<UpdateCollegeCommand>
{
    public UpdateCollegeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.Name).MaximumLength(50);

    }
}