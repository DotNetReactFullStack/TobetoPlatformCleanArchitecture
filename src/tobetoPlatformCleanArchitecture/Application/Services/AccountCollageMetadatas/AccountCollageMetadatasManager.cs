using Application.Features.AccountCollageMetadatas.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCollageMetadatas;

public class AccountCollageMetadatasManager : IAccountCollageMetadatasService
{
    private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
    private readonly AccountCollageMetadataBusinessRules _accountCollageMetadataBusinessRules;

    public AccountCollageMetadatasManager(IAccountCollageMetadataRepository accountCollageMetadataRepository, AccountCollageMetadataBusinessRules accountCollageMetadataBusinessRules)
    {
        _accountCollageMetadataRepository = accountCollageMetadataRepository;
        _accountCollageMetadataBusinessRules = accountCollageMetadataBusinessRules;
    }

    public async Task<AccountCollageMetadata?> GetAsync(
        Expression<Func<AccountCollageMetadata, bool>> predicate,
        Func<IQueryable<AccountCollageMetadata>, IIncludableQueryable<AccountCollageMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountCollageMetadata? accountCollageMetadata = await _accountCollageMetadataRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountCollageMetadata;
    }

    public async Task<IPaginate<AccountCollageMetadata>?> GetListAsync(
        Expression<Func<AccountCollageMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountCollageMetadata>, IOrderedQueryable<AccountCollageMetadata>>? orderBy = null,
        Func<IQueryable<AccountCollageMetadata>, IIncludableQueryable<AccountCollageMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountCollageMetadata> accountCollageMetadataList = await _accountCollageMetadataRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountCollageMetadataList;
    }

    public async Task<AccountCollageMetadata> AddAsync(AccountCollageMetadata accountCollageMetadata)
    {
        AccountCollageMetadata addedAccountCollageMetadata = await _accountCollageMetadataRepository.AddAsync(accountCollageMetadata);

        return addedAccountCollageMetadata;
    }

    public async Task<AccountCollageMetadata> UpdateAsync(AccountCollageMetadata accountCollageMetadata)
    {
        AccountCollageMetadata updatedAccountCollageMetadata = await _accountCollageMetadataRepository.UpdateAsync(accountCollageMetadata);

        return updatedAccountCollageMetadata;
    }

    public async Task<AccountCollageMetadata> DeleteAsync(AccountCollageMetadata accountCollageMetadata, bool permanent = false)
    {
        AccountCollageMetadata deletedAccountCollageMetadata = await _accountCollageMetadataRepository.DeleteAsync(accountCollageMetadata);

        return deletedAccountCollageMetadata;
    }
}
