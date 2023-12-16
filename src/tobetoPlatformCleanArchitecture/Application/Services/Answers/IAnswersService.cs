using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Answers;

public interface IAnswersService
{
    Task<Answer?> GetAsync(
        Expression<Func<Answer, bool>> predicate,
        Func<IQueryable<Answer>, IIncludableQueryable<Answer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Answer>?> GetListAsync(
        Expression<Func<Answer, bool>>? predicate = null,
        Func<IQueryable<Answer>, IOrderedQueryable<Answer>>? orderBy = null,
        Func<IQueryable<Answer>, IIncludableQueryable<Answer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Answer> AddAsync(Answer answer);
    Task<Answer> UpdateAsync(Answer answer);
    Task<Answer> DeleteAsync(Answer answer, bool permanent = false);
}
