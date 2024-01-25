using FluentValidation;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.JobTitle).NotEmpty();
        RuleFor(c => c.Industry).NotEmpty();
        RuleFor(c => c.StartingDate).NotEmpty();
        RuleFor(c => c.EndingDate).NotEmpty();
        RuleFor(c => c.IsCurrentlyWorking).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}