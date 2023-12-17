using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Recourses;

public interface IRecoursesService
{
    Task<Recourse?> GetAsync(
        Expression<Func<Recourse, bool>> predicate,
        Func<IQueryable<Recourse>, IIncludableQueryable<Recourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Recourse>?> GetListAsync(
        Expression<Func<Recourse, bool>>? predicate = null,
        Func<IQueryable<Recourse>, IOrderedQueryable<Recourse>>? orderBy = null,
        Func<IQueryable<Recourse>, IIncludableQueryable<Recourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Recourse> AddAsync(Recourse recourse);
    Task<Recourse> UpdateAsync(Recourse recourse);
    Task<Recourse> DeleteAsync(Recourse recourse, bool permanent = false);
}
