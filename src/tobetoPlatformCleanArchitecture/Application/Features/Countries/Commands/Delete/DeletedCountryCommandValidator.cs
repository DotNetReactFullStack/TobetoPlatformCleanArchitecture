using FluentValidation;

namespace Application.Features.Countries.Commands.Delete;

public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
{
    public DeleteCountryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}