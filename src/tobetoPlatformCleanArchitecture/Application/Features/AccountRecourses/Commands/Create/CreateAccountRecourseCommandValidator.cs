using FluentValidation;

namespace Application.Features.AccountRecourses.Commands.Create;

public class CreateAccountRecourseCommandValidator : AbstractValidator<CreateAccountRecourseCommand>
{
    public CreateAccountRecourseCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.RecourseId).NotEmpty();
        RuleFor(c => c.RecourseStepId).NotEmpty();
    }
}