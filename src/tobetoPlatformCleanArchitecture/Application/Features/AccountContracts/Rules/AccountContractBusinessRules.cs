using Application.Features.AccountContracts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountContracts.Rules;

public class AccountContractBusinessRules : BaseBusinessRules
{
    private readonly IAccountContractRepository _accountContractRepository;

    public AccountContractBusinessRules(IAccountContractRepository accountContractRepository)
    {
        _accountContractRepository = accountContractRepository;
    }

    public Task AccountContractShouldExistWhenSelected(AccountContract? accountContract)
    {
        if (accountContract == null)
            throw new BusinessException(AccountContractsBusinessMessages.AccountContractNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountContractIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountContract? accountContract = await _accountContractRepository.GetAsync(
            predicate: ac => ac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountContractShouldExistWhenSelected(accountContract);
    }
}