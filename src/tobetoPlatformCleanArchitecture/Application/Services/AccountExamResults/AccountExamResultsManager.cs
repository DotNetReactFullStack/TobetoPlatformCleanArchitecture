using Application.Features.AccountExamResults.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountExamResults;

public class AccountExamResultsManager : IAccountExamResultsService
{
    private readonly IAccountExamResultRepository _accountExamResultRepository;
    private readonly AccountExamResultBusinessRules _accountExamResultBusinessRules;

    public AccountExamResultsManager(IAccountExamResultRepository accountExamResultRepository, AccountExamResultBusinessRules accountExamResultBusinessRules)
    {
        _accountExamResultRepository = accountExamResultRepository;
        _accountExamResultBusinessRules = accountExamResultBusinessRules;
    }

    public async Task<AccountExamResult?> GetAsync(
        Expression<Func<AccountExamResult, bool>> predicate,
        Func<IQueryable<AccountExamResult>, IIncludableQueryable<AccountExamResult, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountExamResult? accountExamResult = await _accountExamResultRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountExamResult;
    }

    public async Task<IPaginate<AccountExamResult>?> GetListAsync(
        Expression<Func<AccountExamResult, bool>>? predicate = null,
        Func<IQueryable<AccountExamResult>, IOrderedQueryable<AccountExamResult>>? orderBy = null,
        Func<IQueryable<AccountExamResult>, IIncludableQueryable<AccountExamResult, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountExamResult> accountExamResultList = await _accountExamResultRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountExamResultList;
    }

    public async Task<AccountExamResult> AddAsync(AccountExamResult accountExamResult)
    {
        AccountExamResult addedAccountExamResult = await _accountExamResultRepository.AddAsync(accountExamResult);

        return addedAccountExamResult;
    }

    public async Task<AccountExamResult> UpdateAsync(AccountExamResult accountExamResult)
    {
        AccountExamResult updatedAccountExamResult = await _accountExamResultRepository.UpdateAsync(accountExamResult);

        return updatedAccountExamResult;
    }

    public async Task<AccountExamResult> DeleteAsync(AccountExamResult accountExamResult, bool permanent = false)
    {
        AccountExamResult deletedAccountExamResult = await _accountExamResultRepository.DeleteAsync(accountExamResult);

        return deletedAccountExamResult;
    }
}
