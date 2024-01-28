using FluentValidation;

namespace Application.Features.EducationPrograms.Commands.Create;

public class CreateEducationProgramCommandValidator : AbstractValidator<CreateEducationProgramCommand>
{
    public CreateEducationProgramCommandValidator()
    {
        RuleFor(c => c.CollegeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(70);
        RuleFor(c => c.Visibility).NotEmpty();
    }
}