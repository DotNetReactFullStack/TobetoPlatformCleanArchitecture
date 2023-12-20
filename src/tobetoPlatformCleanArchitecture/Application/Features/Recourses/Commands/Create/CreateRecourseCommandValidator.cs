using FluentValidation;

namespace Application.Features.Recourses.Commands.Create;

public class CreateRecourseCommandValidator : AbstractValidator<CreateRecourseCommand>
{
    public CreateRecourseCommandValidator()
    {
        RuleFor(c => c.OrganizationId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.PublishedDate).NotEmpty();
    }
}