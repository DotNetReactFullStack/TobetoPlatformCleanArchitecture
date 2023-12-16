using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Lessons;

public interface ILessonsService
{
    Task<Lesson?> GetAsync(
        Expression<Func<Lesson, bool>> predicate,
        Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Lesson>?> GetListAsync(
        Expression<Func<Lesson, bool>>? predicate = null,
        Func<IQueryable<Lesson>, IOrderedQueryable<Lesson>>? orderBy = null,
        Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Lesson> AddAsync(Lesson lesson);
    Task<Lesson> UpdateAsync(Lesson lesson);
    Task<Lesson> DeleteAsync(Lesson lesson, bool permanent = false);
}
