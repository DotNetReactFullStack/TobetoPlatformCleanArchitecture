using FluentValidation;

namespace Application.Features.Questions.Commands.Delete;

public class DeleteQuestionCommandValidator : AbstractValidator<DeleteQuestionCommand>
{
    public DeleteQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}