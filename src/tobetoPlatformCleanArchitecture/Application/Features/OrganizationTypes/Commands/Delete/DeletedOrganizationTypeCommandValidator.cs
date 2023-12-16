using FluentValidation;

namespace Application.Features.OrganizationTypes.Commands.Delete;

public class DeleteOrganizationTypeCommandValidator : AbstractValidator<DeleteOrganizationTypeCommand>
{
    public DeleteOrganizationTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}