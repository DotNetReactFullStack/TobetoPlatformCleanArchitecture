using FluentValidation;

namespace Application.Features.QuestionCategories.Commands.Delete;

public class DeleteQuestionCategoryCommandValidator : AbstractValidator<DeleteQuestionCategoryCommand>
{
    public DeleteQuestionCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}