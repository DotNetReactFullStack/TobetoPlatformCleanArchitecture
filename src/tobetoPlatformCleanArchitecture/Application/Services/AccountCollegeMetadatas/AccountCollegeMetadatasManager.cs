using Application.Features.AccountCollegeMetadatas.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCollegeMetadatas;

public class AccountCollegeMetadatasManager : IAccountCollegeMetadatasService
{
    private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
    private readonly AccountCollegeMetadataBusinessRules _accountCollegeMetadataBusinessRules;

    public AccountCollegeMetadatasManager(IAccountCollegeMetadataRepository accountCollegeMetadataRepository, AccountCollegeMetadataBusinessRules accountCollegeMetadataBusinessRules)
    {
        _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
        _accountCollegeMetadataBusinessRules = accountCollegeMetadataBusinessRules;
    }

    public async Task<AccountCollegeMetadata?> GetAsync(
        Expression<Func<AccountCollegeMetadata, bool>> predicate,
        Func<IQueryable<AccountCollegeMetadata>, IIncludableQueryable<AccountCollegeMetadata, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountCollegeMetadata? accountCollegeMetadata = await _accountCollegeMetadataRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountCollegeMetadata;
    }

    public async Task<IPaginate<AccountCollegeMetadata>?> GetListAsync(
        Expression<Func<AccountCollegeMetadata, bool>>? predicate = null,
        Func<IQueryable<AccountCollegeMetadata>, IOrderedQueryable<AccountCollegeMetadata>>? orderBy = null,
        Func<IQueryable<AccountCollegeMetadata>, IIncludableQueryable<AccountCollegeMetadata, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountCollegeMetadata> accountCollegeMetadataList = await _accountCollegeMetadataRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountCollegeMetadataList;
    }

    public async Task<AccountCollegeMetadata> AddAsync(AccountCollegeMetadata accountCollegeMetadata)
    {
        AccountCollegeMetadata addedAccountCollegeMetadata = await _accountCollegeMetadataRepository.AddAsync(accountCollegeMetadata);

        return addedAccountCollegeMetadata;
    }

    public async Task<AccountCollegeMetadata> UpdateAsync(AccountCollegeMetadata accountCollegeMetadata)
    {
        AccountCollegeMetadata updatedAccountCollegeMetadata = await _accountCollegeMetadataRepository.UpdateAsync(accountCollegeMetadata);

        return updatedAccountCollegeMetadata;
    }

    public async Task<AccountCollegeMetadata> DeleteAsync(AccountCollegeMetadata accountCollegeMetadata, bool permanent = false)
    {
        AccountCollegeMetadata deletedAccountCollegeMetadata = await _accountCollegeMetadataRepository.DeleteAsync(accountCollegeMetadata);

        return deletedAccountCollegeMetadata;
    }
}
