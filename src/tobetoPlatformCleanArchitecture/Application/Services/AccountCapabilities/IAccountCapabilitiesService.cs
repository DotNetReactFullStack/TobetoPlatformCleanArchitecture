using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCapabilities;

public interface IAccountCapabilitiesService
{
    Task<AccountCapability?> GetAsync(
        Expression<Func<AccountCapability, bool>> predicate,
        Func<IQueryable<AccountCapability>, IIncludableQueryable<AccountCapability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountCapability>?> GetListAsync(
        Expression<Func<AccountCapability, bool>>? predicate = null,
        Func<IQueryable<AccountCapability>, IOrderedQueryable<AccountCapability>>? orderBy = null,
        Func<IQueryable<AccountCapability>, IIncludableQueryable<AccountCapability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountCapability> AddAsync(AccountCapability accountCapability);
    Task<AccountCapability> UpdateAsync(AccountCapability accountCapability);
    Task<AccountCapability> DeleteAsync(AccountCapability accountCapability, bool permanent = false);
}
