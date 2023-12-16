using Application.Features.LearningPaths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LearningPaths;

public class LearningPathsManager : ILearningPathsService
{
    private readonly ILearningPathRepository _learningPathRepository;
    private readonly LearningPathBusinessRules _learningPathBusinessRules;

    public LearningPathsManager(ILearningPathRepository learningPathRepository, LearningPathBusinessRules learningPathBusinessRules)
    {
        _learningPathRepository = learningPathRepository;
        _learningPathBusinessRules = learningPathBusinessRules;
    }

    public async Task<LearningPath?> GetAsync(
        Expression<Func<LearningPath, bool>> predicate,
        Func<IQueryable<LearningPath>, IIncludableQueryable<LearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LearningPath? learningPath = await _learningPathRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return learningPath;
    }

    public async Task<IPaginate<LearningPath>?> GetListAsync(
        Expression<Func<LearningPath, bool>>? predicate = null,
        Func<IQueryable<LearningPath>, IOrderedQueryable<LearningPath>>? orderBy = null,
        Func<IQueryable<LearningPath>, IIncludableQueryable<LearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LearningPath> learningPathList = await _learningPathRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return learningPathList;
    }

    public async Task<LearningPath> AddAsync(LearningPath learningPath)
    {
        LearningPath addedLearningPath = await _learningPathRepository.AddAsync(learningPath);

        return addedLearningPath;
    }

    public async Task<LearningPath> UpdateAsync(LearningPath learningPath)
    {
        LearningPath updatedLearningPath = await _learningPathRepository.UpdateAsync(learningPath);

        return updatedLearningPath;
    }

    public async Task<LearningPath> DeleteAsync(LearningPath learningPath, bool permanent = false)
    {
        LearningPath deletedLearningPath = await _learningPathRepository.DeleteAsync(learningPath);

        return deletedLearningPath;
    }
}
