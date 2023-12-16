using FluentValidation;

namespace Application.Features.ExamQuestions.Commands.Delete;

public class DeleteExamQuestionCommandValidator : AbstractValidator<DeleteExamQuestionCommand>
{
    public DeleteExamQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}