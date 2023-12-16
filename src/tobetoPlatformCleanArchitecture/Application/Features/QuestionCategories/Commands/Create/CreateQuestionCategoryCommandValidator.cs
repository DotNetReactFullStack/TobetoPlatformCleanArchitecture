using FluentValidation;

namespace Application.Features.QuestionCategories.Commands.Create;

public class CreateQuestionCategoryCommandValidator : AbstractValidator<CreateQuestionCategoryCommand>
{
    public CreateQuestionCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
    }
}