using Application.Features.AccountForeignLanguageMetadatas.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountForeignLanguageMetadatas.Rules;

public class AccountForeignLanguageMetadataBusinessRules : BaseBusinessRules
{
    private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;

    public AccountForeignLanguageMetadataBusinessRules(IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository)
    {
        _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
    }

    public Task AccountForeignLanguageMetadataShouldExistWhenSelected(AccountForeignLanguageMetadata? accountForeignLanguageMetadata)
    {
        if (accountForeignLanguageMetadata == null)
            throw new BusinessException(AccountForeignLanguageMetadatasBusinessMessages.AccountForeignLanguageMetadataNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountForeignLanguageMetadataIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountForeignLanguageMetadata? accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetAsync(
            predicate: aflm => aflm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountForeignLanguageMetadataShouldExistWhenSelected(accountForeignLanguageMetadata);
    }
}