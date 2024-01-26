using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LearningPathCategories;

public interface ILearningPathCategoriesService
{
    Task<LearningPathCategory?> GetAsync(
        Expression<Func<LearningPathCategory, bool>> predicate,
        Func<IQueryable<LearningPathCategory>, IIncludableQueryable<LearningPathCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LearningPathCategory>?> GetListAsync(
        Expression<Func<LearningPathCategory, bool>>? predicate = null,
        Func<IQueryable<LearningPathCategory>, IOrderedQueryable<LearningPathCategory>>? orderBy = null,
        Func<IQueryable<LearningPathCategory>, IIncludableQueryable<LearningPathCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LearningPathCategory> AddAsync(LearningPathCategory learningPathCategory);
    Task<LearningPathCategory> UpdateAsync(LearningPathCategory learningPathCategory);
    Task<LearningPathCategory> DeleteAsync(LearningPathCategory learningPathCategory, bool permanent = false);
}
