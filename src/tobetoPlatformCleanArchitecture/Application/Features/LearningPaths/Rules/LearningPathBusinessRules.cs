using Application.Features.LearningPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LearningPaths.Rules;

public class LearningPathBusinessRules : BaseBusinessRules
{
    private readonly ILearningPathRepository _learningPathRepository;

    public LearningPathBusinessRules(ILearningPathRepository learningPathRepository)
    {
        _learningPathRepository = learningPathRepository;
    }

    public Task LearningPathShouldExistWhenSelected(LearningPath? learningPath)
    {
        if (learningPath == null)
            throw new BusinessException(LearningPathsBusinessMessages.LearningPathNotExists);
        return Task.CompletedTask;
    }

    public async Task LearningPathIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LearningPath? learningPath = await _learningPathRepository.GetAsync(
            predicate: lp => lp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LearningPathShouldExistWhenSelected(learningPath);
    }
}