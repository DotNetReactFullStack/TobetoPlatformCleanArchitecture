using FluentValidation;

namespace Application.Features.Accounts.Commands.Update;

public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.NationalIdentificationNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.ProfilePhotoPath).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}