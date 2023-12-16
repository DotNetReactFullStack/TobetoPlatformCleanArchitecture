using Application.Features.Organizations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Organizations.Rules;

public class OrganizationBusinessRules : BaseBusinessRules
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationBusinessRules(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public Task OrganizationShouldExistWhenSelected(Organization? organization)
    {
        if (organization == null)
            throw new BusinessException(OrganizationsBusinessMessages.OrganizationNotExists);
        return Task.CompletedTask;
    }

    public async Task OrganizationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Organization? organization = await _organizationRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrganizationShouldExistWhenSelected(organization);
    }
}