using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Countries;

public interface ICountriesService
{
    Task<Country?> GetAsync(
        Expression<Func<Country, bool>> predicate,
        Func<IQueryable<Country>, IIncludableQueryable<Country, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Country>?> GetListAsync(
        Expression<Func<Country, bool>>? predicate = null,
        Func<IQueryable<Country>, IOrderedQueryable<Country>>? orderBy = null,
        Func<IQueryable<Country>, IIncludableQueryable<Country, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Country> AddAsync(Country country);
    Task<Country> UpdateAsync(Country country);
    Task<Country> DeleteAsync(Country country, bool permanent = false);
}
