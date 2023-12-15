using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Cities;

public interface ICitiesService
{
    Task<City?> GetAsync(
        Expression<Func<City, bool>> predicate,
        Func<IQueryable<City>, IIncludableQueryable<City, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<City>?> GetListAsync(
        Expression<Func<City, bool>>? predicate = null,
        Func<IQueryable<City>, IOrderedQueryable<City>>? orderBy = null,
        Func<IQueryable<City>, IIncludableQueryable<City, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<City> AddAsync(City city);
    Task<City> UpdateAsync(City city);
    Task<City> DeleteAsync(City city, bool permanent = false);
}
