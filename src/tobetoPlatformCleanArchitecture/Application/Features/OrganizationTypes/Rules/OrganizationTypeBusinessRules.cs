using Application.Features.OrganizationTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.OrganizationTypes.Rules;

public class OrganizationTypeBusinessRules : BaseBusinessRules
{
    private readonly IOrganizationTypeRepository _organizationTypeRepository;

    public OrganizationTypeBusinessRules(IOrganizationTypeRepository organizationTypeRepository)
    {
        _organizationTypeRepository = organizationTypeRepository;
    }

    public Task OrganizationTypeShouldExistWhenSelected(OrganizationType? organizationType)
    {
        if (organizationType == null)
            throw new BusinessException(OrganizationTypesBusinessMessages.OrganizationTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task OrganizationTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        OrganizationType? organizationType = await _organizationTypeRepository.GetAsync(
            predicate: ot => ot.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrganizationTypeShouldExistWhenSelected(organizationType);
    }
}