using FluentValidation;

namespace Application.Features.AccountCollegeMetadatas.Commands.Create;

public class CreateAccountCollegeMetadataCommandValidator : AbstractValidator<CreateAccountCollegeMetadataCommand>
{
    public CreateAccountCollegeMetadataCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.GraduationStatusId).NotEmpty();
        RuleFor(c => c.CollegeId).NotEmpty();
        RuleFor(c => c.EducationProgramId).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.StartingYear).NotEmpty();
        //RuleFor(c => c.GraduationYear).NotEmpty();
        RuleFor(c => c.ProgramOnGoing).NotNull();
    }
}