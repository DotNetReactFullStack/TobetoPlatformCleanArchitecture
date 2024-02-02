using FluentValidation;

namespace Application.Features.RecourseDetails.Commands.Create;

public class CreateRecourseDetailCommandValidator : AbstractValidator<CreateRecourseDetailCommand>
{
    public CreateRecourseDetailCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}