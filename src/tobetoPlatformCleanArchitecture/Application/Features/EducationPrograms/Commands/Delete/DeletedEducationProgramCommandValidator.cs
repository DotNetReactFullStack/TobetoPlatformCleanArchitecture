using FluentValidation;

namespace Application.Features.EducationPrograms.Commands.Delete;

public class DeleteEducationProgramCommandValidator : AbstractValidator<DeleteEducationProgramCommand>
{
    public DeleteEducationProgramCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}