using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Organizations;

public interface IOrganizationsService
{
    Task<Organization?> GetAsync(
        Expression<Func<Organization, bool>> predicate,
        Func<IQueryable<Organization>, IIncludableQueryable<Organization, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Organization>?> GetListAsync(
        Expression<Func<Organization, bool>>? predicate = null,
        Func<IQueryable<Organization>, IOrderedQueryable<Organization>>? orderBy = null,
        Func<IQueryable<Organization>, IIncludableQueryable<Organization, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Organization> AddAsync(Organization organization);
    Task<Organization> UpdateAsync(Organization organization);
    Task<Organization> DeleteAsync(Organization organization, bool permanent = false);
}
