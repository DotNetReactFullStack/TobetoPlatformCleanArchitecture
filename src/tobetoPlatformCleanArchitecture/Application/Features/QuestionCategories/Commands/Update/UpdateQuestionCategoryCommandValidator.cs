using FluentValidation;

namespace Application.Features.QuestionCategories.Commands.Update;

public class UpdateQuestionCategoryCommandValidator : AbstractValidator<UpdateQuestionCategoryCommand>
{
    public UpdateQuestionCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
    }
}