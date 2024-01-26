using Application.Features.ContractTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ContractTypes.Rules;

public class ContractTypeBusinessRules : BaseBusinessRules
{
    private readonly IContractTypeRepository _contractTypeRepository;

    public ContractTypeBusinessRules(IContractTypeRepository contractTypeRepository)
    {
        _contractTypeRepository = contractTypeRepository;
    }

    public Task ContractTypeShouldExistWhenSelected(ContractType? contractType)
    {
        if (contractType == null)
            throw new BusinessException(ContractTypesBusinessMessages.ContractTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task ContractTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ContractType? contractType = await _contractTypeRepository.GetAsync(
            predicate: ct => ct.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ContractTypeShouldExistWhenSelected(contractType);
    }
}