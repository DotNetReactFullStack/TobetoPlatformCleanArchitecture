using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialMediaPlatforms;

public interface ISocialMediaPlatformsService
{
    Task<SocialMediaPlatform?> GetAsync(
        Expression<Func<SocialMediaPlatform, bool>> predicate,
        Func<IQueryable<SocialMediaPlatform>, IIncludableQueryable<SocialMediaPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SocialMediaPlatform>?> GetListAsync(
        Expression<Func<SocialMediaPlatform, bool>>? predicate = null,
        Func<IQueryable<SocialMediaPlatform>, IOrderedQueryable<SocialMediaPlatform>>? orderBy = null,
        Func<IQueryable<SocialMediaPlatform>, IIncludableQueryable<SocialMediaPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SocialMediaPlatform> AddAsync(SocialMediaPlatform socialMediaPlatform);
    Task<SocialMediaPlatform> UpdateAsync(SocialMediaPlatform socialMediaPlatform);
    Task<SocialMediaPlatform> DeleteAsync(SocialMediaPlatform socialMediaPlatform, bool permanent = false);
}
