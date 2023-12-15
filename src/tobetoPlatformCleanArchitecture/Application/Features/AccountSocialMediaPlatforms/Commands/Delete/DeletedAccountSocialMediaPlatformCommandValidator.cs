using FluentValidation;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Delete;

public class DeleteAccountSocialMediaPlatformCommandValidator : AbstractValidator<DeleteAccountSocialMediaPlatformCommand>
{
    public DeleteAccountSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}