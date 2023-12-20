using FluentValidation;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommand>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.NumberOfQuestions).NotEmpty();
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndingTime).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.Duration).NotEmpty();
    }
}