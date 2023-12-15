using FluentValidation;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Update;

public class UpdateAccountSocialMediaPlatformCommandValidator : AbstractValidator<UpdateAccountSocialMediaPlatformCommand>
{
    public UpdateAccountSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.SocialMediaPlatformId).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
    }
}