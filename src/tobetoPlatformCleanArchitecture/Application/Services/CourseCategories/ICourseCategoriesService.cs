using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseCategories;

public interface ICourseCategoriesService
{
    Task<CourseCategory?> GetAsync(
        Expression<Func<CourseCategory, bool>> predicate,
        Func<IQueryable<CourseCategory>, IIncludableQueryable<CourseCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseCategory>?> GetListAsync(
        Expression<Func<CourseCategory, bool>>? predicate = null,
        Func<IQueryable<CourseCategory>, IOrderedQueryable<CourseCategory>>? orderBy = null,
        Func<IQueryable<CourseCategory>, IIncludableQueryable<CourseCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseCategory> AddAsync(CourseCategory courseCategory);
    Task<CourseCategory> UpdateAsync(CourseCategory courseCategory);
    Task<CourseCategory> DeleteAsync(CourseCategory courseCategory, bool permanent = false);
}
