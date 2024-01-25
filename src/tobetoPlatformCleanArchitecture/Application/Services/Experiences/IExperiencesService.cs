using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Experiences;

public interface IExperiencesService
{
    Task<Experience?> GetAsync(
        Expression<Func<Experience, bool>> predicate,
        Func<IQueryable<Experience>, IIncludableQueryable<Experience, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Experience>?> GetListAsync(
        Expression<Func<Experience, bool>>? predicate = null,
        Func<IQueryable<Experience>, IOrderedQueryable<Experience>>? orderBy = null,
        Func<IQueryable<Experience>, IIncludableQueryable<Experience, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Experience> AddAsync(Experience experience);
    Task<Experience> UpdateAsync(Experience experience);
    Task<Experience> DeleteAsync(Experience experience, bool permanent = false);
}
