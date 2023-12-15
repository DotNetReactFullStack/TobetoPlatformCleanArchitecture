using Application.Features.AccountForeignLanguageMetadatas.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountForeignLanguageMetadatas;

public class AccountForeignLanguageMetadatasManager : IAccountForeignLanguageMetadatasService
{
    private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
    private readonly AccountForeignLanguageMetadataBusinessRules _accountForeignLanguageMetadataBusinessRules;

    public AccountForeignLanguageMetadatasManager(IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository, AccountForeignLanguageMetadataBusinessRules accountForeignLanguageMetadataBusinessRules)
    {
        _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
        _accountForeignLanguageMetadataBusinessRules = accountForeignLanguageMetadataBusinessRules;
    }

    public async Task<AccountForeignLanguageMetadata?> GetAsync(
        Expression<Func<AccountForeignLanguageMetadata, bool>> predicate,
        Func<IQueryable<AccountForeignLanguageMetadata>, IIncludableQueryable<AccountForeignLanguageMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountForeignLanguageMetadata? accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountForeignLanguageMetadata;
    }

    public async Task<IPaginate<AccountForeignLanguageMetadata>?> GetListAsync(
        Expression<Func<AccountForeignLanguageMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountForeignLanguageMetadata>, IOrderedQueryable<AccountForeignLanguageMetadata>>? orderBy = null,
        Func<IQueryable<AccountForeignLanguageMetadata>, IIncludableQueryable<AccountForeignLanguageMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountForeignLanguageMetadata> accountForeignLanguageMetadataList = await _accountForeignLanguageMetadataRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountForeignLanguageMetadataList;
    }

    public async Task<AccountForeignLanguageMetadata> AddAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata)
    {
        AccountForeignLanguageMetadata addedAccountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.AddAsync(accountForeignLanguageMetadata);

        return addedAccountForeignLanguageMetadata;
    }

    public async Task<AccountForeignLanguageMetadata> UpdateAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata)
    {
        AccountForeignLanguageMetadata updatedAccountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.UpdateAsync(accountForeignLanguageMetadata);

        return updatedAccountForeignLanguageMetadata;
    }

    public async Task<AccountForeignLanguageMetadata> DeleteAsync(AccountForeignLanguageMetadata accountForeignLanguageMetadata, bool permanent = false)
    {
        AccountForeignLanguageMetadata deletedAccountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.DeleteAsync(accountForeignLanguageMetadata);

        return deletedAccountForeignLanguageMetadata;
    }
}
