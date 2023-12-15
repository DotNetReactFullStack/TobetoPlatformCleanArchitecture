using Application.Features.Capabilities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Capabilities.Rules;

public class CapabilityBusinessRules : BaseBusinessRules
{
    private readonly ICapabilityRepository _capabilityRepository;

    public CapabilityBusinessRules(ICapabilityRepository capabilityRepository)
    {
        _capabilityRepository = capabilityRepository;
    }

    public Task CapabilityShouldExistWhenSelected(Capability? capability)
    {
        if (capability == null)
            throw new BusinessException(CapabilitiesBusinessMessages.CapabilityNotExists);
        return Task.CompletedTask;
    }

    public async Task CapabilityIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Capability? capability = await _capabilityRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CapabilityShouldExistWhenSelected(capability);
    }
}