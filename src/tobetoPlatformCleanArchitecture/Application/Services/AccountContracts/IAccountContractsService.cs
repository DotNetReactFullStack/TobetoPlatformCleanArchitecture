using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountContracts;

public interface IAccountContractsService
{
    Task<AccountContract?> GetAsync(
        Expression<Func<AccountContract, bool>> predicate,
        Func<IQueryable<AccountContract>, IIncludableQueryable<AccountContract, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountContract>?> GetListAsync(
        Expression<Func<AccountContract, bool>>? predicate = null,
        Func<IQueryable<AccountContract>, IOrderedQueryable<AccountContract>>? orderBy = null,
        Func<IQueryable<AccountContract>, IIncludableQueryable<AccountContract, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountContract> AddAsync(AccountContract accountContract);
    Task<AccountContract> UpdateAsync(AccountContract accountContract);
    Task<AccountContract> DeleteAsync(AccountContract accountContract, bool permanent = false);
}
