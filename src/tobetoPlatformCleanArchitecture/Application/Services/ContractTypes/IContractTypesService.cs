using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ContractTypes;

public interface IContractTypesService
{
    Task<ContractType?> GetAsync(
        Expression<Func<ContractType, bool>> predicate,
        Func<IQueryable<ContractType>, IIncludableQueryable<ContractType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ContractType>?> GetListAsync(
        Expression<Func<ContractType, bool>>? predicate = null,
        Func<IQueryable<ContractType>, IOrderedQueryable<ContractType>>? orderBy = null,
        Func<IQueryable<ContractType>, IIncludableQueryable<ContractType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ContractType> AddAsync(ContractType contractType);
    Task<ContractType> UpdateAsync(ContractType contractType);
    Task<ContractType> DeleteAsync(ContractType contractType, bool permanent = false);
}
