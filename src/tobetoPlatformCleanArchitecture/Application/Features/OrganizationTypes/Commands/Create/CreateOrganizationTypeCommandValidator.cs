using FluentValidation;

namespace Application.Features.OrganizationTypes.Commands.Create;

public class CreateOrganizationTypeCommandValidator : AbstractValidator<CreateOrganizationTypeCommand>
{
    public CreateOrganizationTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}