using FluentValidation;

namespace Application.Features.Answers.Commands.Create;

public class CreateAnswerCommandValidator : AbstractValidator<CreateAnswerCommand>
{
    public CreateAnswerCommandValidator()
    {
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerDetail).NotEmpty();
        RuleFor(c => c.RightAnswerBool).NotEmpty();
    }
}