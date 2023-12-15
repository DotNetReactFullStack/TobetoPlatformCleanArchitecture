using FluentValidation;

namespace Application.Features.AccountCollageMetadatas.Commands.Update;

public class UpdateAccountCollageMetadataCommandValidator : AbstractValidator<UpdateAccountCollageMetadataCommand>
{
    public UpdateAccountCollageMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.GraduationStatusId).NotEmpty();
        RuleFor(c => c.CollegeId).NotEmpty();
        RuleFor(c => c.EducationProgramId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.StartingYear).NotEmpty();
        RuleFor(c => c.GraduationYear).NotEmpty();
        RuleFor(c => c.ProgramOnGoing).NotEmpty();
    }
}