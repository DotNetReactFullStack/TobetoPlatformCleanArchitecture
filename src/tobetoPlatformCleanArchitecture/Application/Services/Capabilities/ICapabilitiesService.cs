using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Capabilities;

public interface ICapabilitiesService
{
    Task<Capability?> GetAsync(
        Expression<Func<Capability, bool>> predicate,
        Func<IQueryable<Capability>, IIncludableQueryable<Capability, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Capability>?> GetListAsync(
        Expression<Func<Capability, bool>>? predicate = null,
        Func<IQueryable<Capability>, IOrderedQueryable<Capability>>? orderBy = null,
        Func<IQueryable<Capability>, IIncludableQueryable<Capability, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Capability> AddAsync(Capability capability);
    Task<Capability> UpdateAsync(Capability capability);
    Task<Capability> DeleteAsync(Capability capability, bool permanent = false);
}
