using FluentValidation;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty().MaximumLength(30);
        RuleFor(c => c.JobTitle).NotEmpty().MaximumLength(40);
        RuleFor(c => c.Industry).NotEmpty().MaximumLength(30);
        RuleFor(c => c.StartingDate).NotEmpty();
        RuleFor(c => c.EndingDate).NotEmpty();
        RuleFor(c => c.IsCurrentlyWorking).NotEmpty();
        RuleFor(c => c.Description).NotEmpty().MaximumLength(1000);
        RuleFor(c => c.IsActive).NotEmpty();
    }
}