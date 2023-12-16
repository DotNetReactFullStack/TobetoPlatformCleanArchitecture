using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.QuestionCategories;

public interface IQuestionCategoriesService
{
    Task<QuestionCategory?> GetAsync(
        Expression<Func<QuestionCategory, bool>> predicate,
        Func<IQueryable<QuestionCategory>, IIncludableQueryable<QuestionCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<QuestionCategory>?> GetListAsync(
        Expression<Func<QuestionCategory, bool>>? predicate = null,
        Func<IQueryable<QuestionCategory>, IOrderedQueryable<QuestionCategory>>? orderBy = null,
        Func<IQueryable<QuestionCategory>, IIncludableQueryable<QuestionCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<QuestionCategory> AddAsync(QuestionCategory questionCategory);
    Task<QuestionCategory> UpdateAsync(QuestionCategory questionCategory);
    Task<QuestionCategory> DeleteAsync(QuestionCategory questionCategory, bool permanent = false);
}
