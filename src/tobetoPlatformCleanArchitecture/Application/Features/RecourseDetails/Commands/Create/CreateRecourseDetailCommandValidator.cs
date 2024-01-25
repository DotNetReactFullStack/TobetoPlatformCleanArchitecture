using FluentValidation;

namespace Application.Features.RecourseDetails.Commands.Create;

public class CreateRecourseDetailCommandValidator : AbstractValidator<CreateRecourseDetailCommand>
{
    public CreateRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}