using FluentValidation;

namespace Application.Features.Surveys.Commands.Delete;

public class DeleteSurveyCommandValidator : AbstractValidator<DeleteSurveyCommand>
{
    public DeleteSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}