using FluentValidation;

namespace Application.Features.EducationPrograms.Commands.Update;

public class UpdateEducationProgramCommandValidator : AbstractValidator<UpdateEducationProgramCommand>
{
    public UpdateEducationProgramCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CollegeId).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
        RuleFor(c => c.Name).MaximumLength(50);
        RuleFor(c => c.Visibility).NotNull();
    }
}