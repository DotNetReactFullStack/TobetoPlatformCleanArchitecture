using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Colleges;

public interface ICollegesService
{
    Task<College?> GetAsync(
        Expression<Func<College, bool>> predicate,
        Func<IQueryable<College>, IIncludableQueryable<College, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<College>?> GetListAsync(
        Expression<Func<College, bool>>? predicate = null,
        Func<IQueryable<College>, IOrderedQueryable<College>>? orderBy = null,
        Func<IQueryable<College>, IIncludableQueryable<College, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<College> AddAsync(College college);
    Task<College> UpdateAsync(College college);
    Task<College> DeleteAsync(College college, bool permanent = false);
}
