using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Questions;

public interface IQuestionsService
{
    Task<Question?> GetAsync(
        Expression<Func<Question, bool>> predicate,
        Func<IQueryable<Question>, IIncludableQueryable<Question, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Question>?> GetListAsync(
        Expression<Func<Question, bool>>? predicate = null,
        Func<IQueryable<Question>, IOrderedQueryable<Question>>? orderBy = null,
        Func<IQueryable<Question>, IIncludableQueryable<Question, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Question> AddAsync(Question question);
    Task<Question> UpdateAsync(Question question);
    Task<Question> DeleteAsync(Question question, bool permanent = false);
}
