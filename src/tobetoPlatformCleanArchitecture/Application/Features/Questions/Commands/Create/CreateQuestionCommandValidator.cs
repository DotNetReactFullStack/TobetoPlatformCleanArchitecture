using FluentValidation;

namespace Application.Features.Questions.Commands.Create;

public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionCommandValidator()
    {
        RuleFor(c => c.QuestionCategoryId).NotEmpty();
        RuleFor(c => c.QuestionDetail).NotEmpty().MaximumLength(1000);
        RuleFor(c => c.IsActive).NotNull();
    }
}