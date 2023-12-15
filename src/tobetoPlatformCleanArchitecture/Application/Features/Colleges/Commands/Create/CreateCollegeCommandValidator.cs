using FluentValidation;

namespace Application.Features.Colleges.Commands.Create;

public class CreateCollegeCommandValidator : AbstractValidator<CreateCollegeCommand>
{
    public CreateCollegeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}