using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountLearningPaths;

public interface IAccountLearningPathsService
{
    Task<AccountLearningPath?> GetAsync(
        Expression<Func<AccountLearningPath, bool>> predicate,
        Func<IQueryable<AccountLearningPath>, IIncludableQueryable<AccountLearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountLearningPath>?> GetListAsync(
        Expression<Func<AccountLearningPath, bool>>? predicate = null,
        Func<IQueryable<AccountLearningPath>, IOrderedQueryable<AccountLearningPath>>? orderBy = null,
        Func<IQueryable<AccountLearningPath>, IIncludableQueryable<AccountLearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountLearningPath> AddAsync(AccountLearningPath accountLearningPath);
    Task<AccountLearningPath> UpdateAsync(AccountLearningPath accountLearningPath);
    Task<AccountLearningPath> DeleteAsync(AccountLearningPath accountLearningPath, bool permanent = false);
}
