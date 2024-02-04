using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserWithNationalIdentificationNumberForRegisterDto.UserForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.UserWithNationalIdentificationNumberForRegisterDto.UserForRegisterDto.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.UserWithNationalIdentificationNumberForRegisterDto.UserForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.UserWithNationalIdentificationNumberForRegisterDto.UserForRegisterDto.Password).NotEmpty().MinimumLength(4);
        RuleFor(c => c.UserWithNationalIdentificationNumberForRegisterDto.NationalIdentificationNumber).Length(11).Matches(new Regex(@"^[1-9]{1}[0-9]{9}[02468]{1}$"));
    }
}
