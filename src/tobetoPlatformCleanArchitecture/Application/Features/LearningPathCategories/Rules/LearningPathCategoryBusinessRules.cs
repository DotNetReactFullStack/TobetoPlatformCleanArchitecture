using Application.Features.LearningPathCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.LearningPathCategories.Rules;

public class LearningPathCategoryBusinessRules : BaseBusinessRules
{
    private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;

    public LearningPathCategoryBusinessRules(ILearningPathCategoryRepository learningPathCategoryRepository)
    {
        _learningPathCategoryRepository = learningPathCategoryRepository;
    }

    public Task LearningPathCategoryShouldExistWhenSelected(LearningPathCategory? learningPathCategory)
    {
        if (learningPathCategory == null)
            throw new BusinessException(LearningPathCategoriesBusinessMessages.LearningPathCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task LearningPathCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        LearningPathCategory? learningPathCategory = await _learningPathCategoryRepository.GetAsync(
            predicate: lpc => lpc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LearningPathCategoryShouldExistWhenSelected(learningPathCategory);
    }
}