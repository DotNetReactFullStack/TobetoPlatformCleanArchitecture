using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ForeignLanguageLevels;

public interface IForeignLanguageLevelsService
{
    Task<ForeignLanguageLevel?> GetAsync(
        Expression<Func<ForeignLanguageLevel, bool>> predicate,
        Func<IQueryable<ForeignLanguageLevel>, IIncludableQueryable<ForeignLanguageLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ForeignLanguageLevel>?> GetListAsync(
        Expression<Func<ForeignLanguageLevel, bool>>? predicate = null,
        Func<IQueryable<ForeignLanguageLevel>, IOrderedQueryable<ForeignLanguageLevel>>? orderBy = null,
        Func<IQueryable<ForeignLanguageLevel>, IIncludableQueryable<ForeignLanguageLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ForeignLanguageLevel> AddAsync(ForeignLanguageLevel foreignLanguageLevel);
    Task<ForeignLanguageLevel> UpdateAsync(ForeignLanguageLevel foreignLanguageLevel);
    Task<ForeignLanguageLevel> DeleteAsync(ForeignLanguageLevel foreignLanguageLevel, bool permanent = false);
}
