using Application.Features.Organizations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Organizations;

public class OrganizationsManager : IOrganizationsService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly OrganizationBusinessRules _organizationBusinessRules;

    public OrganizationsManager(IOrganizationRepository organizationRepository, OrganizationBusinessRules organizationBusinessRules)
    {
        _organizationRepository = organizationRepository;
        _organizationBusinessRules = organizationBusinessRules;
    }

    public async Task<Organization?> GetAsync(
        Expression<Func<Organization, bool>> predicate,
        Func<IQueryable<Organization>, IIncludableQueryable<Organization, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Organization? organization = await _organizationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return organization;
    }

    public async Task<IPaginate<Organization>?> GetListAsync(
        Expression<Func<Organization, bool>>? predicate = null,
        Func<IQueryable<Organization>, IOrderedQueryable<Organization>>? orderBy = null,
        Func<IQueryable<Organization>, IIncludableQueryable<Organization, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Organization> organizationList = await _organizationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return organizationList;
    }

    public async Task<Organization> AddAsync(Organization organization)
    {
        Organization addedOrganization = await _organizationRepository.AddAsync(organization);

        return addedOrganization;
    }

    public async Task<Organization> UpdateAsync(Organization organization)
    {
        Organization updatedOrganization = await _organizationRepository.UpdateAsync(organization);

        return updatedOrganization;
    }

    public async Task<Organization> DeleteAsync(Organization organization, bool permanent = false)
    {
        Organization deletedOrganization = await _organizationRepository.DeleteAsync(organization);

        return deletedOrganization;
    }
}
