using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountForeignLanguageMetadatas;

public interface IAccountForeignLanguageMetadatasService
{
    Task<AccountForeignLanguageMetadata?> GetAsync(
        Expression<Func<AccountForeignLanguageMetadata, bool>> predicate,
        Func<IQueryable<AccountForeignLanguageMetadata>, IIncludableQueryable<AccountForeignLanguageMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountForeignLanguageMetadata>?> GetListAsync(
        Expression<Func<AccountForeignLanguageMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountForeignLanguageMetadata>, IOrderedQueryable<AccountForeignLanguageMetadata>>? orderBy = null,
        Func<IQueryable<AccountForeignLanguageMetadata>, IIncludableQueryable<AccountForeignLanguageMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountForeignLanguageMetadata> AddAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata);
    Task<AccountForeignLanguageMetadata> UpdateAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata);
    Task<AccountForeignLanguageMetadata> DeleteAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata, bool permanent = false);
}
