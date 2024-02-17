using FluentValidation;

namespace Application.Features.AccountCollegeMetadatas.Commands.Update;

public class UpdateAccountCollegeMetadataCommandValidator : AbstractValidator<UpdateAccountCollegeMetadataCommand>
{
    public UpdateAccountCollegeMetadataCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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