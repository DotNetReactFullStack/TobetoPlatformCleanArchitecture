using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountSocialMediaPlatforms;

public interface IAccountSocialMediaPlatformsService
{
    Task<AccountSocialMediaPlatform?> GetAsync(
        Expression<Func<AccountSocialMediaPlatform, bool>> predicate,
        Func<IQueryable<AccountSocialMediaPlatform>, IIncludableQueryable<AccountSocialMediaPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountSocialMediaPlatform>?> GetListAsync(
        Expression<Func<AccountSocialMediaPlatform, bool>>? predicate = null,
        Func<IQueryable<AccountSocialMediaPlatform>, IOrderedQueryable<AccountSocialMediaPlatform>>? orderBy = null,
        Func<IQueryable<AccountSocialMediaPlatform>, IIncludableQueryable<AccountSocialMediaPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountSocialMediaPlatform> AddAsync(AccountSocialMediaPlatform accountSocialMediaPlatform);
    Task<AccountSocialMediaPlatform> UpdateAsync(AccountSocialMediaPlatform accountSocialMediaPlatform);
    Task<AccountSocialMediaPlatform> DeleteAsync(AccountSocialMediaPlatform accountSocialMediaPlatform, bool permanent = false);
}
