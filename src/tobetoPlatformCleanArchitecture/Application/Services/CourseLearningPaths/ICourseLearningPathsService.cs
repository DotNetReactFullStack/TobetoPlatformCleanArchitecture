using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseLearningPaths;

public interface ICourseLearningPathsService
{
    Task<CourseLearningPath?> GetAsync(
        Expression<Func<CourseLearningPath, bool>> predicate,
        Func<IQueryable<CourseLearningPath>, IIncludableQueryable<CourseLearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CourseLearningPath>?> GetListAsync(
        Expression<Func<CourseLearningPath, bool>>? predicate = null,
        Func<IQueryable<CourseLearningPath>, IOrderedQueryable<CourseLearningPath>>? orderBy = null,
        Func<IQueryable<CourseLearningPath>, IIncludableQueryable<CourseLearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CourseLearningPath> AddAsync(CourseLearningPath courseLearningPath);
    Task<CourseLearningPath> UpdateAsync(CourseLearningPath courseLearningPath);
    Task<CourseLearningPath> DeleteAsync(CourseLearningPath courseLearningPath, bool permanent = false);
}
