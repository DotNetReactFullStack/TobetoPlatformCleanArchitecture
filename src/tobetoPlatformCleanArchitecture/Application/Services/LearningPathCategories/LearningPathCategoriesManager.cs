using Application.Features.LearningPathCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LearningPathCategories;

public class LearningPathCategoriesManager : ILearningPathCategoriesService
{
    private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
    private readonly LearningPathCategoryBusinessRules _learningPathCategoryBusinessRules;

    public LearningPathCategoriesManager(ILearningPathCategoryRepository learningPathCategoryRepository, LearningPathCategoryBusinessRules learningPathCategoryBusinessRules)
    {
        _learningPathCategoryRepository = learningPathCategoryRepository;
        _learningPathCategoryBusinessRules = learningPathCategoryBusinessRules;
    }

    public async Task<LearningPathCategory?> GetAsync(
        Expression<Func<LearningPathCategory, bool>> predicate,
        Func<IQueryable<LearningPathCategory>, IIncludableQueryable<LearningPathCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LearningPathCategory? learningPathCategory = await _learningPathCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return learningPathCategory;
    }

    public async Task<IPaginate<LearningPathCategory>?> GetListAsync(
        Expression<Func<LearningPathCategory, bool>>? predicate = null,
        Func<IQueryable<LearningPathCategory>, IOrderedQueryable<LearningPathCategory>>? orderBy = null,
        Func<IQueryable<LearningPathCategory>, IIncludableQueryable<LearningPathCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LearningPathCategory> learningPathCategoryList = await _learningPathCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return learningPathCategoryList;
    }

    public async Task<LearningPathCategory> AddAsync(LearningPathCategory learningPathCategory)
    {
        LearningPathCategory addedLearningPathCategory = await _learningPathCategoryRepository.AddAsync(learningPathCategory);

        return addedLearningPathCategory;
    }

    public async Task<LearningPathCategory> UpdateAsync(LearningPathCategory learningPathCategory)
    {
        LearningPathCategory updatedLearningPathCategory = await _learningPathCategoryRepository.UpdateAsync(learningPathCategory);

        return updatedLearningPathCategory;
    }

    public async Task<LearningPathCategory> DeleteAsync(LearningPathCategory learningPathCategory, bool permanent = false)
    {
        LearningPathCategory deletedLearningPathCategory = await _learningPathCategoryRepository.DeleteAsync(learningPathCategory);

        return deletedLearningPathCategory;
    }
}
