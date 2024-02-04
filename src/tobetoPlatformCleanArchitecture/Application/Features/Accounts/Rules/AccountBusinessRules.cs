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

    public Task IsUserAlreadyLinkedToAccount(Account? account)
    {
        var accountCount = _accountRepository.GetList(a => a.UserId == account.UserId).Count;

        bool isLinked = accountCount == AccountsBusinessRuleConstants.MaximumNumberOfAccountsForEachUser ? true : false;

        if (isLinked)
        {
            throw new BusinessException(AccountsBusinessMessages.UserCanHaveAtMostOneAccount);
        }
        return Task.CompletedTask;
    }

    public Task NationalIdentificationNumberMustBeUnique(Account? account)
    {
        var isUnique = _accountRepository.Get(a => a.NationalIdentificationNumber == account.NationalIdentificationNumber) == null
                   ? false : true;

        if (isUnique)
        {
            throw new BusinessException(AccountsBusinessMessages.NationalIdentificationNumberMustBeUnique);
        }
        return Task.CompletedTask;
    }

    //// Uncomment for NationalIdentificationNumber to be updateable
    //public Task UserCanOnlyUpdateTheirOwnAccount(Account? account)
    //{
    //    var isAllowed = _accountRepository
    //        .Get(a => a.UserId == account.UserId
    //               && a.NationalIdentificationNumber == account.NationalIdentificationNumber)
    //                    != null
    //                    ? false : true;

    //    if (isAllowed)
    //    {
    //        throw new BusinessException(AccountsBusinessMessages.UserCanOnlyUpdateTheirOwnAccount);
    //    }
    //    return Task.CompletedTask;
    //}
}