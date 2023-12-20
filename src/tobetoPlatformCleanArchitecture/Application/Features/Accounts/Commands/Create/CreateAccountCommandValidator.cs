using FluentValidation;

namespace Application.Features.Accounts.Commands.Create;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.NationalIdentificationNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.ProfilePhotoPath).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}