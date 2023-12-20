using Application.Features.Accounts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Accounts.Rules;

public class AccountBusinessRules : BaseBusinessRules
{
    private readonly IAccountRepository _accountRepository;

    public AccountBusinessRules(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task AccountShouldExistWhenSelected(Account? account)
    {
        if (account == null)
            throw new BusinessException(AccountsBusinessMessages.AccountNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Account? account = await _accountRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountShouldExistWhenSelected(account);
    }
}