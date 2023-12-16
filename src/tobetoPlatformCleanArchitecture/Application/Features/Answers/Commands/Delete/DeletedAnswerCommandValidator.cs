using FluentValidation;

namespace Application.Features.Answers.Commands.Delete;

public class DeleteAnswerCommandValidator : AbstractValidator<DeleteAnswerCommand>
{
    public DeleteAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}