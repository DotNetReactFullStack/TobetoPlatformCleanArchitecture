using Application.Features.AccountSocialMediaPlatforms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountSocialMediaPlatforms;

public class AccountSocialMediaPlatformsManager : IAccountSocialMediaPlatformsService
{
    private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;
    private readonly AccountSocialMediaPlatformBusinessRules _accountSocialMediaPlatformBusinessRules;

    public AccountSocialMediaPlatformsManager(IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository, AccountSocialMediaPlatformBusinessRules accountSocialMediaPlatformBusinessRules)
    {
        _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
        _accountSocialMediaPlatformBusinessRules = accountSocialMediaPlatformBusinessRules;
    }

    public async Task<AccountSocialMediaPlatform?> GetAsync(
        Expression<Func<AccountSocialMediaPlatform, bool>> predicate,
        Func<IQueryable<AccountSocialMediaPlatform>, IIncludableQueryable<AccountSocialMediaPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountSocialMediaPlatform? accountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountSocialMediaPlatform;
    }

    public async Task<IPaginate<AccountSocialMediaPlatform>?> GetListAsync(
        Expression<Func<AccountSocialMediaPlatform, bool>>? predicate = null,
        Func<IQueryable<AccountSocialMediaPlatform>, IOrderedQueryable<AccountSocialMediaPlatform>>? orderBy = null,
        Func<IQueryable<AccountSocialMediaPlatform>, IIncludableQueryable<AccountSocialMediaPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountSocialMediaPlatform> accountSocialMediaPlatformList = await _accountSocialMediaPlatformRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountSocialMediaPlatformList;
    }

    public async Task<AccountSocialMediaPlatform> AddAsync(AccountSocialMediaPlatform accountSocialMediaPlatform)
    {
        AccountSocialMediaPlatform addedAccountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.AddAsync(accountSocialMediaPlatform);

        return addedAccountSocialMediaPlatform;
    }

    public async Task<AccountSocialMediaPlatform> UpdateAsync(AccountSocialMediaPlatform accountSocialMediaPlatform)
    {
        AccountSocialMediaPlatform updatedAccountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.UpdateAsync(accountSocialMediaPlatform);

        return updatedAccountSocialMediaPlatform;
    }

    public async Task<AccountSocialMediaPlatform> DeleteAsync(AccountSocialMediaPlatform accountSocialMediaPlatform, bool permanent = false)
    {
        AccountSocialMediaPlatform deletedAccountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.DeleteAsync(accountSocialMediaPlatform);

        return deletedAccountSocialMediaPlatform;
    }
}
