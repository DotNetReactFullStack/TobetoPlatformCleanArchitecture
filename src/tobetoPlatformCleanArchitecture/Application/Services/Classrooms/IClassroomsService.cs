using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Classrooms;

public interface IClassroomsService
{
    Task<Classroom?> GetAsync(
        Expression<Func<Classroom, bool>> predicate,
        Func<IQueryable<Classroom>, IIncludableQueryable<Classroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Classroom>?> GetListAsync(
        Expression<Func<Classroom, bool>>? predicate = null,
        Func<IQueryable<Classroom>, IOrderedQueryable<Classroom>>? orderBy = null,
        Func<IQueryable<Classroom>, IIncludableQueryable<Classroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Classroom> AddAsync(Classroom classroom);
    Task<Classroom> UpdateAsync(Classroom classroom);
    Task<Classroom> DeleteAsync(Classroom classroom, bool permanent = false);
}
