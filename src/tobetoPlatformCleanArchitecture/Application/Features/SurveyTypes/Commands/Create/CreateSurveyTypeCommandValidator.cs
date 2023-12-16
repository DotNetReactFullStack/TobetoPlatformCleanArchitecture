using FluentValidation;

namespace Application.Features.SurveyTypes.Commands.Create;

public class CreateSurveyTypeCommandValidator : AbstractValidator<CreateSurveyTypeCommand>
{
    public CreateSurveyTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}