using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCollegeMetadatas;

public interface IAccountCollegeMetadatasService
{
    Task<AccountCollegeMetadata?> GetAsync(
        Expression<Func<AccountCollegeMetadata, bool>> predicate,
        Func<IQueryable<AccountCollegeMetadata>, IIncludableQueryable<AccountCollegeMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountCollegeMetadata>?> GetListAsync(
        Expression<Func<AccountCollegeMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountCollegeMetadata>, IOrderedQueryable<AccountCollegeMetadata>>? orderBy = null,
        Func<IQueryable<AccountCollegeMetadata>, IIncludableQueryable<AccountCollegeMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountCollegeMetadata> AddAsync(AccountCollegeMetadata accountCollegeMetadata);
    Task<AccountCollegeMetadata> UpdateAsync(AccountCollegeMetadata accountCollegeMetadata);
    Task<AccountCollegeMetadata> DeleteAsync(AccountCollegeMetadata accountCollegeMetadata, bool permanent = false);
}
