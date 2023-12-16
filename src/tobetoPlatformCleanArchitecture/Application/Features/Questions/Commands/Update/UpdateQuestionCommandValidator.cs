using FluentValidation;

namespace Application.Features.Questions.Commands.Update;

public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
{
    public UpdateQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.QuestionCategoryId).NotEmpty();
        RuleFor(c => c.QuestionDetail).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}