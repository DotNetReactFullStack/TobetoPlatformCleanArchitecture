using FluentValidation;

namespace Application.Features.RecourseDetails.Commands.Update;

public class UpdateRecourseDetailCommandValidator : AbstractValidator<UpdateRecourseDetailCommand>
{
    public UpdateRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}