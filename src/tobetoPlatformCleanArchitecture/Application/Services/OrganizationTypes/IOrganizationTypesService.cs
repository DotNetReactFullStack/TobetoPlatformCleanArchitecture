using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrganizationTypes;

public interface IOrganizationTypesService
{
    Task<OrganizationType?> GetAsync(
        Expression<Func<OrganizationType, bool>> predicate,
        Func<IQueryable<OrganizationType>, IIncludableQueryable<OrganizationType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrganizationType>?> GetListAsync(
        Expression<Func<OrganizationType, bool>>? predicate = null,
        Func<IQueryable<OrganizationType>, IOrderedQueryable<OrganizationType>>? orderBy = null,
        Func<IQueryable<OrganizationType>, IIncludableQueryable<OrganizationType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrganizationType> AddAsync(OrganizationType organizationType);
    Task<OrganizationType> UpdateAsync(OrganizationType organizationType);
    Task<OrganizationType> DeleteAsync(OrganizationType organizationType, bool permanent = false);
}
