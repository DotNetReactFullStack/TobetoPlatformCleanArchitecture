using FluentValidation;

namespace Application.Features.Recourses.Commands.Create;

public class CreateRecourseCommandValidator : AbstractValidator<CreateRecourseCommand>
{
    public CreateRecourseCommandValidator()
    {
        RuleFor(c => c.OrganizationId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
        RuleFor(c => c.Title).NotEmpty().MaximumLength(50);
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
        RuleFor(c => c.PublishedDate).NotEmpty();
    }
}