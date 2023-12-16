using FluentValidation;

namespace Application.Features.ExamQuestions.Commands.Update;

public class UpdateExamQuestionCommandValidator : AbstractValidator<UpdateExamQuestionCommand>
{
    public UpdateExamQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
    }
}