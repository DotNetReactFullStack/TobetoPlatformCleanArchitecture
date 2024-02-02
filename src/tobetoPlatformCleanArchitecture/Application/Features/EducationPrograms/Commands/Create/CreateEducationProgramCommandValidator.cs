using FluentValidation;

namespace Application.Features.EducationPrograms.Commands.Create;

public class CreateEducationProgramCommandValidator : AbstractValidator<CreateEducationProgramCommand>
{
    public CreateEducationProgramCommandValidator()
    {
        RuleFor(c => c.CollegeId).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.Name).MaximumLength(50);
        RuleFor(c => c.Visibility).NotNull();
    }
}