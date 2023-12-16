using FluentValidation;

namespace Application.Features.ExamQuestions.Commands.Create;

public class CreateExamQuestionCommandValidator : AbstractValidator<CreateExamQuestionCommand>
{
    public CreateExamQuestionCommandValidator()
    {
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
    }
}