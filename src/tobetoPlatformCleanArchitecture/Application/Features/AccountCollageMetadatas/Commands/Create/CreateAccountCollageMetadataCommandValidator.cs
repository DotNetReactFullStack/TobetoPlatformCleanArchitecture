using FluentValidation;

namespace Application.Features.AccountCollageMetadatas.Commands.Create;

public class CreateAccountCollageMetadataCommandValidator : AbstractValidator<CreateAccountCollageMetadataCommand>
{
    public CreateAccountCollageMetadataCommandValidator()
    {
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