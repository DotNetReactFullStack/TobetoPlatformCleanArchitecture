using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Contracts;

public interface IContractsService
{
    Task<Contract?> GetAsync(
        Expression<Func<Contract, bool>> predicate,
        Func<IQueryable<Contract>, IIncludableQueryable<Contract, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Contract>?> GetListAsync(
        Expression<Func<Contract, bool>>? predicate = null,
        Func<IQueryable<Contract>, IOrderedQueryable<Contract>>? orderBy = null,
        Func<IQueryable<Contract>, IIncludableQueryable<Contract, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Contract> AddAsync(Contract contract);
    Task<Contract> UpdateAsync(Contract contract);
    Task<Contract> DeleteAsync(Contract contract, bool permanent = false);
}
