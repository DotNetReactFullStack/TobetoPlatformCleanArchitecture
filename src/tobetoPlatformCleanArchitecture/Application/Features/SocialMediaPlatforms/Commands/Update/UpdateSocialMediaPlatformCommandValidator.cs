using FluentValidation;

namespace Application.Features.SocialMediaPlatforms.Commands.Update;

public class UpdateSocialMediaPlatformCommandValidator : AbstractValidator<UpdateSocialMediaPlatformCommand>
{
    public UpdateSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IconPath).NotEmpty();
        RuleFor(c => c.Priority).NotEmpty();
        RuleFor(c => c.Visibility).NotEmpty();
    }
}