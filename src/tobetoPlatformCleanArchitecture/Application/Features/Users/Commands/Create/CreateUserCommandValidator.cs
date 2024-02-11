using FluentValidation;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.LastName).NotEmpty().MinimumLength(2).MaximumLength(30);
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Password).NotEmpty().MinimumLength(8).MaximumLength(36);
    }
}
