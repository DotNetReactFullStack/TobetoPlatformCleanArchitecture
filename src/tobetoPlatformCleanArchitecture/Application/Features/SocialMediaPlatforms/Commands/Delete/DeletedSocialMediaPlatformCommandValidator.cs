using FluentValidation;

namespace Application.Features.SocialMediaPlatforms.Commands.Delete;

public class DeleteSocialMediaPlatformCommandValidator : AbstractValidator<DeleteSocialMediaPlatformCommand>
{
    public DeleteSocialMediaPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}