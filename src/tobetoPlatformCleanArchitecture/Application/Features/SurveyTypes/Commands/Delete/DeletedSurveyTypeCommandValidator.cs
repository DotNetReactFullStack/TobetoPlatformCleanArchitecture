using FluentValidation;

namespace Application.Features.SurveyTypes.Commands.Delete;

public class DeleteSurveyTypeCommandValidator : AbstractValidator<DeleteSurveyTypeCommand>
{
    public DeleteSurveyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}