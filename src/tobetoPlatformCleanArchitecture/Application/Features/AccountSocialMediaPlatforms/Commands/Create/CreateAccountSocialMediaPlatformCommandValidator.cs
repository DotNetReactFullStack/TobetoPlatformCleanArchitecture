using FluentValidation;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Create;

public class CreateAccountSocialMediaPlatformCommandValidator : AbstractValidator<CreateAccountSocialMediaPlatformCommand>
{
    public CreateAccountSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.SocialMediaPlatformId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
    }
}