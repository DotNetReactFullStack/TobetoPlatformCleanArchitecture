using FluentValidation;

namespace Application.Features.SocialMediaPlatforms.Commands.Create;

public class CreateSocialMediaPlatformCommandValidator : AbstractValidator<CreateSocialMediaPlatformCommand>
{
    public CreateSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IconPath).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}