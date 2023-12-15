using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Addresses;

public interface IAddressesService
{
    Task<Address?> GetAsync(
        Expression<Func<Address, bool>> predicate,
        Func<IQueryable<Address>, IIncludableQueryable<Address, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Address>?> GetListAsync(
        Expression<Func<Address, bool>>? predicate = null,
        Func<IQueryable<Address>, IOrderedQueryable<Address>>? orderBy = null,
        Func<IQueryable<Address>, IIncludableQueryable<Address, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Address> AddAsync(Address address);
    Task<Address> UpdateAsync(Address address);
    Task<Address> DeleteAsync(Address address, bool permanent = false);
}
