using FluentValidation;

namespace Application.Features.AccountRecourseDetails.Commands.Create;

public class CreateAccountRecourseDetailCommandValidator : AbstractValidator<CreateAccountRecourseDetailCommand>
{
    public CreateAccountRecourseDetailCommandValidator()
    {
        RuleFor(c => c.AccountRecourseId).NotEmpty();
        RuleFor(c => c.RecourseDetailStepId).NotEmpty();
        RuleFor(c => c.RecourseDetailId).NotEmpty();
    }
}