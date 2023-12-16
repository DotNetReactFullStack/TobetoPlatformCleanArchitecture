using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Courses;

public interface ICoursesService
{
    Task<Course?> GetAsync(
        Expression<Func<Course, bool>> predicate,
        Func<IQueryable<Course>, IIncludableQueryable<Course, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Course>?> GetListAsync(
        Expression<Func<Course, bool>>? predicate = null,
        Func<IQueryable<Course>, IOrderedQueryable<Course>>? orderBy = null,
        Func<IQueryable<Course>, IIncludableQueryable<Course, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Course> AddAsync(Course course);
    Task<Course> UpdateAsync(Course course);
    Task<Course> DeleteAsync(Course course, bool permanent = false);
}
