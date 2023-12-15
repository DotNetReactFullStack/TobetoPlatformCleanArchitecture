using Application.Features.AccountCapabilities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountCapabilities.Rules;

public class AccountCapabilityBusinessRules : BaseBusinessRules
{
    private readonly IAccountCapabilityRepository _accountCapabilityRepository;

    public AccountCapabilityBusinessRules(IAccountCapabilityRepository accountCapabilityRepository)
    {
        _accountCapabilityRepository = accountCapabilityRepository;
    }

    public Task AccountCapabilityShouldExistWhenSelected(AccountCapability? accountCapability)
    {
        if (accountCapability == null)
            throw new BusinessException(AccountCapabilitiesBusinessMessages.AccountCapabilityNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountCapabilityIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountCapability? accountCapability = await _accountCapabilityRepository.GetAsync(
            predicate: ac => ac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountCapabilityShouldExistWhenSelected(accountCapability);
    }
}