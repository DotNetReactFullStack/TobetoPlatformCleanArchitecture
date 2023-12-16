using Application.Features.AccountLearningPaths.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountLearningPaths;

public class AccountLearningPathsManager : IAccountLearningPathsService
{
    private readonly IAccountLearningPathRepository _accountLearningPathRepository;
    private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

    public AccountLearningPathsManager(IAccountLearningPathRepository accountLearningPathRepository, AccountLearningPathBusinessRules accountLearningPathBusinessRules)
    {
        _accountLearningPathRepository = accountLearningPathRepository;
        _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
    }

    public async Task<AccountLearningPath?> GetAsync(
        Expression<Func<AccountLearningPath, bool>> predicate,
        Func<IQueryable<AccountLearningPath>, IIncludableQueryable<AccountLearningPath, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountLearningPath;
    }

    public async Task<IPaginate<AccountLearningPath>?> GetListAsync(
        Expression<Func<AccountLearningPath, bool>>? predicate = null,
        Func<IQueryable<AccountLearningPath>, IOrderedQueryable<AccountLearningPath>>? orderBy = null,
        Func<IQueryable<AccountLearningPath>, IIncludableQueryable<AccountLearningPath, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountLearningPath> accountLearningPathList = await _accountLearningPathRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountLearningPathList;
    }

    public async Task<AccountLearningPath> AddAsync(AccountLearningPath accountLearningPath)
    {
        AccountLearningPath addedAccountLearningPath = await _accountLearningPathRepository.AddAsync(accountLearningPath);

        return addedAccountLearningPath;
    }

    public async Task<AccountLearningPath> UpdateAsync(AccountLearningPath accountLearningPath)
    {
        AccountLearningPath updatedAccountLearningPath = await _accountLearningPathRepository.UpdateAsync(accountLearningPath);

        return updatedAccountLearningPath;
    }

    public async Task<AccountLearningPath> DeleteAsync(AccountLearningPath accountLearningPath, bool permanent = false)
    {
        AccountLearningPath deletedAccountLearningPath = await _accountLearningPathRepository.DeleteAsync(accountLearningPath);

        return deletedAccountLearningPath;
    }
}
