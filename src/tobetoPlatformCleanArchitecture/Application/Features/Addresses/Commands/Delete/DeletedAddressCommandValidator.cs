using FluentValidation;

namespace Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}