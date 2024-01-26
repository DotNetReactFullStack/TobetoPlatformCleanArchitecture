using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Contracts;

public class ContractsManager : IContractsService
{
    private readonly IContractRepository _contractRepository;
    private readonly ContractBusinessRules _contractBusinessRules;

    public ContractsManager(IContractRepository contractRepository, ContractBusinessRules contractBusinessRules)
    {
        _contractRepository = contractRepository;
        _contractBusinessRules = contractBusinessRules;
    }

    public async Task<Contract?> GetAsync(
        Expression<Func<Contract, bool>> predicate,
        Func<IQueryable<Contract>, IIncludableQueryable<Contract, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Contract? contract = await _contractRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return contract;
    }

    public async Task<IPaginate<Contract>?> GetListAsync(
        Expression<Func<Contract, bool>>? predicate = null,
        Func<IQueryable<Contract>, IOrderedQueryable<Contract>>? orderBy = null,
        Func<IQueryable<Contract>, IIncludableQueryable<Contract, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Contract> contractList = await _contractRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return contractList;
    }

    public async Task<Contract> AddAsync(Contract contract)
    {
        Contract addedContract = await _contractRepository.AddAsync(contract);

        return addedContract;
    }

    public async Task<Contract> UpdateAsync(Contract contract)
    {
        Contract updatedContract = await _contractRepository.UpdateAsync(contract);

        return updatedContract;
    }

    public async Task<Contract> DeleteAsync(Contract contract, bool permanent = false)
    {
        Contract deletedContract = await _contractRepository.DeleteAsync(contract);

        return deletedContract;
    }
}
