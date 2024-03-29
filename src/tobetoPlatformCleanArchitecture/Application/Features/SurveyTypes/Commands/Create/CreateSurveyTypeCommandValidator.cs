using FluentValidation;

namespace Application.Features.SurveyTypes.Commands.Create;

public class CreateSurveyTypeCommandValidator : AbstractValidator<CreateSurveyTypeCommand>
{
    public CreateSurveyTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}