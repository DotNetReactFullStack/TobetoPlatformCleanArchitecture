using Application.Features.SocialMediaPlatforms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SocialMediaPlatforms.Rules;

public class SocialMediaPlatformBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;

    public SocialMediaPlatformBusinessRules(ISocialMediaPlatformRepository socialMediaPlatformRepository)
    {
        _socialMediaPlatformRepository = socialMediaPlatformRepository;
    }

    public Task SocialMediaPlatformShouldExistWhenSelected(SocialMediaPlatform? socialMediaPlatform)
    {
        if (socialMediaPlatform == null)
            throw new BusinessException(SocialMediaPlatformsBusinessMessages.SocialMediaPlatformNotExists);
        return Task.CompletedTask;
    }

    public async Task SocialMediaPlatformIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SocialMediaPlatform? socialMediaPlatform = await _socialMediaPlatformRepository.GetAsync(
            predicate: smp => smp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialMediaPlatformShouldExistWhenSelected(socialMediaPlatform);
    }
}