using FluentValidation;

namespace Application.Features.Organizations.Commands.Delete;

public class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
{
    public DeleteOrganizationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}