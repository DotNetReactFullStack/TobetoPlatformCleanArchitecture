using FluentValidation;

namespace Application.Features.OrganizationTypes.Commands.Update;

public class UpdateOrganizationTypeCommandValidator : AbstractValidator<UpdateOrganizationTypeCommand>
{
    public UpdateOrganizationTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotNull();
    }
}