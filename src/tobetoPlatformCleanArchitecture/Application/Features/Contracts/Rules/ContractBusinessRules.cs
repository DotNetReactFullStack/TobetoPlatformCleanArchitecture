using Application.Features.Contracts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Contracts.Rules;

public class ContractBusinessRules : BaseBusinessRules
{
    private readonly IContractRepository _contractRepository;

    public ContractBusinessRules(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public Task ContractShouldExistWhenSelected(Contract? contract)
    {
        if (contract == null)
            throw new BusinessException(ContractsBusinessMessages.ContractNotExists);
        return Task.CompletedTask;
    }

    public async Task ContractIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Contract? contract = await _contractRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ContractShouldExistWhenSelected(contract);
    }
}