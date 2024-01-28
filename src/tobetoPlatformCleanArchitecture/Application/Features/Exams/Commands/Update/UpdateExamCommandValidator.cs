using FluentValidation;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommand>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(70);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => (int)c.NumberOfQuestions).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndingTime).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => (int)c.Duration).NotEmpty().GreaterThanOrEqualTo(0);
    }
}