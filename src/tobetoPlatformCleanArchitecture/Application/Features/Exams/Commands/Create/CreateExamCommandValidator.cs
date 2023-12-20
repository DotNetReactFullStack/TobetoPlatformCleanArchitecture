using FluentValidation;

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
{
    public CreateExamCommandValidator()
    {
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