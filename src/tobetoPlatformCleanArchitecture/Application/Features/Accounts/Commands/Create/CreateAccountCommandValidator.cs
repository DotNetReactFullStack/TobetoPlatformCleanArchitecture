using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Accounts.Commands.Create;

public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.NationalIdentificationNumber).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        //RuleFor(c => c.ProfilePhotoPath).NotEmpty();
        RuleFor(c => c.ShareProfile).NotNull();
        RuleFor(c => c.ProfileLinkUrl).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
                                                                    // 555-555-8899
        RuleFor(a => a.PhoneNumber).Length(12).Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"));
        RuleFor(a => a.NationalIdentificationNumber).Length(11).Matches(new Regex(@"^[1-9]{1}[0-9]{9}[02468]{1}$"));
    }
}