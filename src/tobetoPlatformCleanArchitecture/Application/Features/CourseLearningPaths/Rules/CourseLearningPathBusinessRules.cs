using Application.Features.CourseLearningPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseLearningPaths.Rules;

public class CourseLearningPathBusinessRules : BaseBusinessRules
{
    private readonly ICourseLearningPathRepository _courseLearningPathRepository;

    public CourseLearningPathBusinessRules(ICourseLearningPathRepository courseLearningPathRepository)
    {
        _courseLearningPathRepository = courseLearningPathRepository;
    }

    public Task CourseLearningPathShouldExistWhenSelected(CourseLearningPath? courseLearningPath)
    {
        if (courseLearningPath == null)
            throw new BusinessException(CourseLearningPathsBusinessMessages.CourseLearningPathNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseLearningPathIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CourseLearningPath? courseLearningPath = await _courseLearningPathRepository.GetAsync(
            predicate: clp => clp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseLearningPathShouldExistWhenSelected(courseLearningPath);
    }
}