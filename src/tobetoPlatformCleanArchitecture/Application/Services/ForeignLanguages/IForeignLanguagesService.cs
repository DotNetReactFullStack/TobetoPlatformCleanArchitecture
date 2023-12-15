using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ForeignLanguages;

public interface IForeignLanguagesService
{
    Task<ForeignLanguage?> GetAsync(
        Expression<Func<ForeignLanguage, bool>> predicate,
        Func<IQueryable<ForeignLanguage>, IIncludableQueryable<ForeignLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ForeignLanguage>?> GetListAsync(
        Expression<Func<ForeignLanguage, bool>>? predicate = null,
        Func<IQueryable<ForeignLanguage>, IOrderedQueryable<ForeignLanguage>>? orderBy = null,
        Func<IQueryable<ForeignLanguage>, IIncludableQueryable<ForeignLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ForeignLanguage> AddAsync(ForeignLanguage foreignLanguage);
    Task<ForeignLanguage> UpdateAsync(ForeignLanguage foreignLanguage);
    Task<ForeignLanguage> DeleteAsync(ForeignLanguage foreignLanguage, bool permanent = false);
}
