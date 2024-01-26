using Application.Features.ContractTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ContractTypes;

public class ContractTypesManager : IContractTypesService
{
    private readonly IContractTypeRepository _contractTypeRepository;
    private readonly ContractTypeBusinessRules _contractTypeBusinessRules;

    public ContractTypesManager(IContractTypeRepository contractTypeRepository, ContractTypeBusinessRules contractTypeBusinessRules)
    {
        _contractTypeRepository = contractTypeRepository;
        _contractTypeBusinessRules = contractTypeBusinessRules;
    }

    public async Task<ContractType?> GetAsync(
        Expression<Func<ContractType, bool>> predicate,
        Func<IQueryable<ContractType>, IIncludableQueryable<ContractType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ContractType? contractType = await _contractTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return contractType;
    }

    public async Task<IPaginate<ContractType>?> GetListAsync(
        Expression<Func<ContractType, bool>>? predicate = null,
        Func<IQueryable<ContractType>, IOrderedQueryable<ContractType>>? orderBy = null,
        Func<IQueryable<ContractType>, IIncludableQueryable<ContractType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ContractType> contractTypeList = await _contractTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return contractTypeList;
    }

    public async Task<ContractType> AddAsync(ContractType contractType)
    {
        ContractType addedContractType = await _contractTypeRepository.AddAsync(contractType);

        return addedContractType;
    }

    public async Task<ContractType> UpdateAsync(ContractType contractType)
    {
        ContractType updatedContractType = await _contractTypeRepository.UpdateAsync(contractType);

        return updatedContractType;
    }

    public async Task<ContractType> DeleteAsync(ContractType contractType, bool permanent = false)
    {
        ContractType deletedContractType = await _contractTypeRepository.DeleteAsync(contractType);

        return deletedContractType;
    }
}
