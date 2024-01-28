using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Organizations.Commands.Create;

public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationCommandValidator()
    {
        RuleFor(c => c.OrganizationTypeId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
        RuleFor(c => c.Name).NotEmpty().MaximumLength(30);
        RuleFor(c => c.ContactNumber).NotEmpty().Length(12).Matches(new Regex(@"(((\d{3}) ?)|(\d{3}-))?\d{3}-\d{4}"));
    }
}
