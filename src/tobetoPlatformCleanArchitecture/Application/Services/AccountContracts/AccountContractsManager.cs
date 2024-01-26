using Application.Features.AccountContracts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountContracts;

public class AccountContractsManager : IAccountContractsService
{
    private readonly IAccountContractRepository _accountContractRepository;
    private readonly AccountContractBusinessRules _accountContractBusinessRules;

    public AccountContractsManager(IAccountContractRepository accountContractRepository, AccountContractBusinessRules accountContractBusinessRules)
    {
        _accountContractRepository = accountContractRepository;
        _accountContractBusinessRules = accountContractBusinessRules;
    }

    public async Task<AccountContract?> GetAsync(
        Expression<Func<AccountContract, bool>> predicate,
        Func<IQueryable<AccountContract>, IIncludableQueryable<AccountContract, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountContract? accountContract = await _accountContractRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountContract;
    }

    public async Task<IPaginate<AccountContract>?> GetListAsync(
        Expression<Func<AccountContract, bool>>? predicate = null,
        Func<IQueryable<AccountContract>, IOrderedQueryable<AccountContract>>? orderBy = null,
        Func<IQueryable<AccountContract>, IIncludableQueryable<AccountContract, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountContract> accountContractList = await _accountContractRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountContractList;
    }

    public async Task<AccountContract> AddAsync(AccountContract accountContract)
    {
        AccountContract addedAccountContract = await _accountContractRepository.AddAsync(accountContract);

        return addedAccountContract;
    }

    public async Task<AccountContract> UpdateAsync(AccountContract accountContract)
    {
        AccountContract updatedAccountContract = await _accountContractRepository.UpdateAsync(accountContract);

        return updatedAccountContract;
    }

    public async Task<AccountContract> DeleteAsync(AccountContract accountContract, bool permanent = false)
    {
        AccountContract deletedAccountContract = await _accountContractRepository.DeleteAsync(accountContract);

        return deletedAccountContract;
    }
}
