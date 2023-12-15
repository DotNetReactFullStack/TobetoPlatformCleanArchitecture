using Application.Features.Accounts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Accounts;

public class AccountsManager : IAccountsService
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountBusinessRules _accountBusinessRules;

    public AccountsManager(IAccountRepository accountRepository, AccountBusinessRules accountBusinessRules)
    {
        _accountRepository = accountRepository;
        _accountBusinessRules = accountBusinessRules;
    }

    public async Task<Account?> GetAsync(
        Expression<Func<Account, bool>> predicate,
        Func<IQueryable<Account>, IIncludableQueryable<Account, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Account? account = await _accountRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return account;
    }

    public async Task<IPaginate<Account>?> GetListAsync(
        Expression<Func<Account, bool>>? predicate = null,
        Func<IQueryable<Account>, IOrderedQueryable<Account>>? orderBy = null,
        Func<IQueryable<Account>, IIncludableQueryable<Account, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Account> accountList = await _accountRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountList;
    }

    public async Task<Account> AddAsync(Account account)
    {
        Account addedAccount = await _accountRepository.AddAsync(account);

        return addedAccount;
    }

    public async Task<Account> UpdateAsync(Account account)
    {
        Account updatedAccount = await _accountRepository.UpdateAsync(account);

        return updatedAccount;
    }

    public async Task<Account> DeleteAsync(Account account, bool permanent = false)
    {
        Account deletedAccount = await _accountRepository.DeleteAsync(account);

        return deletedAccount;
    }
}
