using Application.Features.QuestionCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.QuestionCategories;

public class QuestionCategoriesManager : IQuestionCategoriesService
{
    private readonly IQuestionCategoryRepository _questionCategoryRepository;
    private readonly QuestionCategoryBusinessRules _questionCategoryBusinessRules;

    public QuestionCategoriesManager(IQuestionCategoryRepository questionCategoryRepository, QuestionCategoryBusinessRules questionCategoryBusinessRules)
    {
        _questionCategoryRepository = questionCategoryRepository;
        _questionCategoryBusinessRules = questionCategoryBusinessRules;
    }

    public async Task<QuestionCategory?> GetAsync(
        Expression<Func<QuestionCategory, bool>> predicate,
        Func<IQueryable<QuestionCategory>, IIncludableQueryable<QuestionCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        QuestionCategory? questionCategory = await _questionCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return questionCategory;
    }

    public async Task<IPaginate<QuestionCategory>?> GetListAsync(
        Expression<Func<QuestionCategory, bool>>? predicate = null,
        Func<IQueryable<QuestionCategory>, IOrderedQueryable<QuestionCategory>>? orderBy = null,
        Func<IQueryable<QuestionCategory>, IIncludableQueryable<QuestionCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<QuestionCategory> questionCategoryList = await _questionCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return questionCategoryList;
    }

    public async Task<QuestionCategory> AddAsync(QuestionCategory questionCategory)
    {
        QuestionCategory addedQuestionCategory = await _questionCategoryRepository.AddAsync(questionCategory);

        return addedQuestionCategory;
    }

    public async Task<QuestionCategory> UpdateAsync(QuestionCategory questionCategory)
    {
        QuestionCategory updatedQuestionCategory = await _questionCategoryRepository.UpdateAsync(questionCategory);

        return updatedQuestionCategory;
    }

    public async Task<QuestionCategory> DeleteAsync(QuestionCategory questionCategory, bool permanent = false)
    {
        QuestionCategory deletedQuestionCategory = await _questionCategoryRepository.DeleteAsync(questionCategory);

        return deletedQuestionCategory;
    }
}
