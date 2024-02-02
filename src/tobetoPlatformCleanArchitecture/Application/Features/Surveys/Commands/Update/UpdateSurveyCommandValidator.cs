using FluentValidation;

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
{
    public UpdateSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SurveyTypeId).NotEmpty();
        RuleFor(c => c.OrganizationId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Title).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.ConnectionLink).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => c.PublishedDate).NotEmpty();
    }
}