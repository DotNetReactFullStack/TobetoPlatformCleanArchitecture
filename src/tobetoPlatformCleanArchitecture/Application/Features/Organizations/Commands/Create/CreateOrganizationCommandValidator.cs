using FluentValidation;

namespace Application.Features.Organizations.Commands.Create;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(c => c.OrganizationTypeId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ContactNumber).NotEmpty();
    }
}