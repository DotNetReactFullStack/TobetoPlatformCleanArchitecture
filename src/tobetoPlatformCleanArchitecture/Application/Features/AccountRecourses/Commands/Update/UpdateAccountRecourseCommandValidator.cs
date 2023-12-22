using FluentValidation;

namespace Application.Features.AccountRecourses.Commands.Update;

public class UpdateAccountRecourseCommandValidator : AbstractValidator<UpdateAccountRecourseCommand>
{
    public UpdateAccountRecourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.RecourseId).NotEmpty();
        RuleFor(c => c.RecourseStepId).NotEmpty();
    }
}