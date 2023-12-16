using Application.Features.CourseLearningPaths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseLearningPaths;

public class CourseLearningPathsManager : ICourseLearningPathsService
{
    private readonly ICourseLearningPathRepository _courseLearningPathRepository;
    private readonly CourseLearningPathBusinessRules _courseLearningPathBusinessRules;

    public CourseLearningPathsManager(ICourseLearningPathRepository courseLearningPathRepository, CourseLearningPathBusinessRules courseLearningPathBusinessRules)
    {
        _courseLearningPathRepository = courseLearningPathRepository;
        _courseLearningPathBusinessRules = courseLearningPathBusinessRules;
    }

    public async Task<CourseLearningPath?> GetAsync(
        Expression<Func<CourseLearningPath, bool>> predicate,
        Func<IQueryable<CourseLearningPath>, IIncludableQueryable<CourseLearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseLearningPath? courseLearningPath = await _courseLearningPathRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseLearningPath;
    }

    public async Task<IPaginate<CourseLearningPath>?> GetListAsync(
        Expression<Func<CourseLearningPath, bool>>? predicate = null,
        Func<IQueryable<CourseLearningPath>, IOrderedQueryable<CourseLearningPath>>? orderBy = null,
        Func<IQueryable<CourseLearningPath>, IIncludableQueryable<CourseLearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseLearningPath> courseLearningPathList = await _courseLearningPathRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseLearningPathList;
    }

    public async Task<CourseLearningPath> AddAsync(CourseLearningPath courseLearningPath)
    {
        CourseLearningPath addedCourseLearningPath = await _courseLearningPathRepository.AddAsync(courseLearningPath);

        return addedCourseLearningPath;
    }

    public async Task<CourseLearningPath> UpdateAsync(CourseLearningPath courseLearningPath)
    {
        CourseLearningPath updatedCourseLearningPath = await _courseLearningPathRepository.UpdateAsync(courseLearningPath);

        return updatedCourseLearningPath;
    }

    public async Task<CourseLearningPath> DeleteAsync(CourseLearningPath courseLearningPath, bool permanent = false)
    {
        CourseLearningPath deletedCourseLearningPath = await _courseLearningPathRepository.DeleteAsync(courseLearningPath);

        return deletedCourseLearningPath;
    }
}
