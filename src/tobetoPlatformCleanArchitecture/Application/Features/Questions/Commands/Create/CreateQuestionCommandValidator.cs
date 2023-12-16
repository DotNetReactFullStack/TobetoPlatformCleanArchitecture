using FluentValidation;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.QuestionCategoryId).NotEmpty();
        RuleFor(c => c.QuestionDetail).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}