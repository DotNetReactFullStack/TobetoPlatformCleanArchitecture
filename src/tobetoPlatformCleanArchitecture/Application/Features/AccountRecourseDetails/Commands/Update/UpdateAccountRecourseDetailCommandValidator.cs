using FluentValidation;

namespace Application.Features.AccountRecourseDetails.Commands.Update;

public class UpdateAccountRecourseDetailCommandValidator : AbstractValidator<UpdateAccountRecourseDetailCommand>
{
    public UpdateAccountRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountRecourseId).NotEmpty();
        RuleFor(c => c.RecourseDetailStepId).NotEmpty();
        RuleFor(c => c.RecourseDetailId).NotEmpty();
    }
}