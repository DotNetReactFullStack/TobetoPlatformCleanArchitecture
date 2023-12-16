using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountExamResults;

public interface IAccountExamResultsService
{
    Task<AccountExamResult?> GetAsync(
        Expression<Func<AccountExamResult, bool>> predicate,
        Func<IQueryable<AccountExamResult>, IIncludableQueryable<AccountExamResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountExamResult>?> GetListAsync(
        Expression<Func<AccountExamResult, bool>>? predicate = null,
        Func<IQueryable<AccountExamResult>, IOrderedQueryable<AccountExamResult>>? orderBy = null,
        Func<IQueryable<AccountExamResult>, IIncludableQueryable<AccountExamResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountExamResult> AddAsync(AccountExamResult accountExamResult);
    Task<AccountExamResult> UpdateAsync(AccountExamResult accountExamResult);
    Task<AccountExamResult> DeleteAsync(AccountExamResult accountExamResult, bool permanent = false);
}
