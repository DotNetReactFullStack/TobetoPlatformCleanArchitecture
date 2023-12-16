using Application.Features.QuestionCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.QuestionCategories.Rules;

public class QuestionCategoryBusinessRules : BaseBusinessRules
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;

    public QuestionCategoryBusinessRules(IQuestionCategoryRepository questionCategoryRepository)
    {
        _questionCategoryRepository = questionCategoryRepository;
    }

    public Task QuestionCategoryShouldExistWhenSelected(QuestionCategory? questionCategory)
    {
        if (questionCategory == null)
            throw new BusinessException(QuestionCategoriesBusinessMessages.QuestionCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task QuestionCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        QuestionCategory? questionCategory = await _questionCategoryRepository.GetAsync(
            predicate: qc => qc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await QuestionCategoryShouldExistWhenSelected(questionCategory);
    }
}