using Application.Features.SocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaPlatforms;

public class SocialMediaPlatformsManager : ISocialMediaPlatformsService
{
    private readonly ISocialMediaPlatformRepository _socialMediaPlatformRepository;
    private readonly SocialMediaPlatformBusinessRules _socialMediaPlatformBusinessRules;

    public SocialMediaPlatformsManager(ISocialMediaPlatformRepository socialMediaPlatformRepository, SocialMediaPlatformBusinessRules socialMediaPlatformBusinessRules)
    {
        _socialMediaPlatformRepository = socialMediaPlatformRepository;
        _socialMediaPlatformBusinessRules = socialMediaPlatformBusinessRules;
    }

    public async Task<SocialMediaPlatform?> GetAsync(
        Expression<Func<SocialMediaPlatform, bool>> predicate,
        Func<IQueryable<SocialMediaPlatform>, IIncludableQueryable<SocialMediaPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SocialMediaPlatform? socialMediaPlatform = await _socialMediaPlatformRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return socialMediaPlatform;
    }

    public async Task<IPaginate<SocialMediaPlatform>?> GetListAsync(
        Expression<Func<SocialMediaPlatform, bool>>? predicate = null,
        Func<IQueryable<SocialMediaPlatform>, IOrderedQueryable<SocialMediaPlatform>>? orderBy = null,
        Func<IQueryable<SocialMediaPlatform>, IIncludableQueryable<SocialMediaPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SocialMediaPlatform> socialMediaPlatformList = await _socialMediaPlatformRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return socialMediaPlatformList;
    }

    public async Task<SocialMediaPlatform> AddAsync(SocialMediaPlatform socialMediaPlatform)
    {
        SocialMediaPlatform addedSocialMediaPlatform = await _socialMediaPlatformRepository.AddAsync(socialMediaPlatform);

        return addedSocialMediaPlatform;
    }

    public async Task<SocialMediaPlatform> UpdateAsync(SocialMediaPlatform socialMediaPlatform)
    {
        SocialMediaPlatform updatedSocialMediaPlatform = await _socialMediaPlatformRepository.UpdateAsync(socialMediaPlatform);

        return updatedSocialMediaPlatform;
    }

    public async Task<SocialMediaPlatform> DeleteAsync(SocialMediaPlatform socialMediaPlatform, bool permanent = false)
    {
        SocialMediaPlatform deletedSocialMediaPlatform = await _socialMediaPlatformRepository.DeleteAsync(socialMediaPlatform);

        return deletedSocialMediaPlatform;
    }
}
