using FluentValidation;

namespace Application.Features.SurveyTypes.Commands.Update;

public class UpdateSurveyTypeCommandValidator : AbstractValidator<UpdateSurveyTypeCommand>
{
    public UpdateSurveyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}