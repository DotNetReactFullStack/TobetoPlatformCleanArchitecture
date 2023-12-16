using Application.Features.OrganizationTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrganizationTypes;

public class OrganizationTypesManager : IOrganizationTypesService
{
    private readonly IOrganizationTypeRepository _organizationTypeRepository;
    private readonly OrganizationTypeBusinessRules _organizationTypeBusinessRules;

    public OrganizationTypesManager(IOrganizationTypeRepository organizationTypeRepository, OrganizationTypeBusinessRules organizationTypeBusinessRules)
    {
        _organizationTypeRepository = organizationTypeRepository;
        _organizationTypeBusinessRules = organizationTypeBusinessRules;
    }

    public async Task<OrganizationType?> GetAsync(
        Expression<Func<OrganizationType, bool>> predicate,
        Func<IQueryable<OrganizationType>, IIncludableQueryable<OrganizationType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrganizationType? organizationType = await _organizationTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return organizationType;
    }

    public async Task<IPaginate<OrganizationType>?> GetListAsync(
        Expression<Func<OrganizationType, bool>>? predicate = null,
        Func<IQueryable<OrganizationType>, IOrderedQueryable<OrganizationType>>? orderBy = null,
        Func<IQueryable<OrganizationType>, IIncludableQueryable<OrganizationType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrganizationType> organizationTypeList = await _organizationTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return organizationTypeList;
    }

    public async Task<OrganizationType> AddAsync(OrganizationType organizationType)
    {
        OrganizationType addedOrganizationType = await _organizationTypeRepository.AddAsync(organizationType);

        return addedOrganizationType;
    }

    public async Task<OrganizationType> UpdateAsync(OrganizationType organizationType)
    {
        OrganizationType updatedOrganizationType = await _organizationTypeRepository.UpdateAsync(organizationType);

        return updatedOrganizationType;
    }

    public async Task<OrganizationType> DeleteAsync(OrganizationType organizationType, bool permanent = false)
    {
        OrganizationType deletedOrganizationType = await _organizationTypeRepository.DeleteAsync(organizationType);

        return deletedOrganizationType;
    }
}
