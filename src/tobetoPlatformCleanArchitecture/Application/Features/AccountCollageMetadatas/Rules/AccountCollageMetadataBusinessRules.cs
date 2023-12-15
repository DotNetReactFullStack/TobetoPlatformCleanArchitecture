using Application.Features.AccountCollageMetadatas.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountCollageMetadatas.Rules;

public class AccountCollageMetadataBusinessRules : BaseBusinessRules
{
    private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;

    public AccountCollageMetadataBusinessRules(IAccountCollageMetadataRepository accountCollageMetadataRepository)
    {
        _accountCollageMetadataRepository = accountCollageMetadataRepository;
    }

    public Task AccountCollageMetadataShouldExistWhenSelected(AccountCollageMetadata? accountCollageMetadata)
    {
        if (accountCollageMetadata == null)
            throw new BusinessException(AccountCollageMetadatasBusinessMessages.AccountCollageMetadataNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountCollageMetadataIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountCollageMetadata? accountCollageMetadata = await _accountCollageMetadataRepository.GetAsync(
            predicate: acm => acm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountCollageMetadataShouldExistWhenSelected(accountCollageMetadata);
    }
}