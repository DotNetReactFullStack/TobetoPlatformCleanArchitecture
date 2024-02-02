using FluentValidation;

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
{
    public CreateExamCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(70);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => (int) c.NumberOfQuestions).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(c => c.StartingTime).NotEmpty();
        RuleFor(c => c.EndingTime).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => (int) c.Duration).NotEmpty().GreaterThanOrEqualTo(0);
    }
}