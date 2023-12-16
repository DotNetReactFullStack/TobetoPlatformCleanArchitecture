using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountLessons;

public interface IAccountLessonsService
{
    Task<AccountLesson?> GetAsync(
        Expression<Func<AccountLesson, bool>> predicate,
        Func<IQueryable<AccountLesson>, IIncludableQueryable<AccountLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountLesson>?> GetListAsync(
        Expression<Func<AccountLesson, bool>>? predicate = null,
        Func<IQueryable<AccountLesson>, IOrderedQueryable<AccountLesson>>? orderBy = null,
        Func<IQueryable<AccountLesson>, IIncludableQueryable<AccountLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountLesson> AddAsync(AccountLesson accountLesson);
    Task<AccountLesson> UpdateAsync(AccountLesson accountLesson);
    Task<AccountLesson> DeleteAsync(AccountLesson accountLesson, bool permanent = false);
}
