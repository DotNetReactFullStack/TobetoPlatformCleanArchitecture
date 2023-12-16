using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LearningPaths;

public interface ILearningPathsService
{
    Task<LearningPath?> GetAsync(
        Expression<Func<LearningPath, bool>> predicate,
        Func<IQueryable<LearningPath>, IIncludableQueryable<LearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LearningPath>?> GetListAsync(
        Expression<Func<LearningPath, bool>>? predicate = null,
        Func<IQueryable<LearningPath>, IOrderedQueryable<LearningPath>>? orderBy = null,
        Func<IQueryable<LearningPath>, IIncludableQueryable<LearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LearningPath> AddAsync(LearningPath learningPath);
    Task<LearningPath> UpdateAsync(LearningPath learningPath);
    Task<LearningPath> DeleteAsync(LearningPath learningPath, bool permanent = false);
}
