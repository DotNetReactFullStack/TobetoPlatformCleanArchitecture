using Application.Features.AccountCapabilities.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCapabilities;

public class AccountCapabilitiesManager : IAccountCapabilitiesService
{
    private readonly IAccountCapabilityRepository _accountCapabilityRepository;
    private readonly AccountCapabilityBusinessRules _accountCapabilityBusinessRules;

    public AccountCapabilitiesManager(IAccountCapabilityRepository accountCapabilityRepository, AccountCapabilityBusinessRules accountCapabilityBusinessRules)
    {
        _accountCapabilityRepository = accountCapabilityRepository;
        _accountCapabilityBusinessRules = accountCapabilityBusinessRules;
    }

    public async Task<AccountCapability?> GetAsync(
        Expression<Func<AccountCapability, bool>> predicate,
        Func<IQueryable<AccountCapability>, IIncludableQueryable<AccountCapability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountCapability? accountCapability = await _accountCapabilityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountCapability;
    }

    public async Task<IPaginate<AccountCapability>?> GetListAsync(
        Expression<Func<AccountCapability, bool>>? predicate = null,
        Func<IQueryable<AccountCapability>, IOrderedQueryable<AccountCapability>>? orderBy = null,
        Func<IQueryable<AccountCapability>, IIncludableQueryable<AccountCapability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountCapability> accountCapabilityList = await _accountCapabilityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountCapabilityList;
    }

    public async Task<AccountCapability> AddAsync(AccountCapability accountCapability)
    {
        AccountCapability addedAccountCapability = await _accountCapabilityRepository.AddAsync(accountCapability);

        return addedAccountCapability;
    }

    public async Task<AccountCapability> UpdateAsync(AccountCapability accountCapability)
    {
        AccountCapability updatedAccountCapability = await _accountCapabilityRepository.UpdateAsync(accountCapability);

        return updatedAccountCapability;
    }

    public async Task<AccountCapability> DeleteAsync(AccountCapability accountCapability, bool permanent = false)
    {
        AccountCapability deletedAccountCapability = await _accountCapabilityRepository.DeleteAsync(accountCapability);

        return deletedAccountCapability;
    }
}
