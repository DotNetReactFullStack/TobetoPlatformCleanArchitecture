using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCollageMetadatas;

public interface IAccountCollageMetadatasService
{
    Task<AccountCollageMetadata?> GetAsync(
        Expression<Func<AccountCollageMetadata, bool>> predicate,
        Func<IQueryable<AccountCollageMetadata>, IIncludableQueryable<AccountCollageMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountCollageMetadata>?> GetListAsync(
        Expression<Func<AccountCollageMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountCollageMetadata>, IOrderedQueryable<AccountCollageMetadata>>? orderBy = null,
        Func<IQueryable<AccountCollageMetadata>, IIncludableQueryable<AccountCollageMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountCollageMetadata> AddAsync(AccountCollageMetadata accountCollageMetadata);
    Task<AccountCollageMetadata> UpdateAsync(AccountCollageMetadata accountCollageMetadata);
    Task<AccountCollageMetadata> DeleteAsync(AccountCollageMetadata accountCollageMetadata, bool permanent = false);
}
