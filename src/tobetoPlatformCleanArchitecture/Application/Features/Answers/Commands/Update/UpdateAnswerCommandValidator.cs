using FluentValidation;

namespace Application.Features.Answers.Commands.Update;

public class UpdateAnswerCommandValidator : AbstractValidator<UpdateAnswerCommand>
{
    public UpdateAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerDetail).NotEmpty();
        RuleFor(c => c.RightAnswerBool).NotEmpty();
    }
}