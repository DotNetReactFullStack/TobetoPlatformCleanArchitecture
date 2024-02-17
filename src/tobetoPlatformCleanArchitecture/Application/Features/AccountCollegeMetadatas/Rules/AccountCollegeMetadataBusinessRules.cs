using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Features.AccountForeignLanguageMetadatas.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountCollegeMetadatas.Rules;

public class AccountCollegeMetadataBusinessRules : BaseBusinessRules
{
    private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;

    public AccountCollegeMetadataBusinessRules(IAccountCollegeMetadataRepository accountCollegeMetadataRepository)
    {
        _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
    }

    public Task AccountCollegeMetadataShouldExistWhenSelected(AccountCollegeMetadata? accountCollegeMetadata)
    {
        if (accountCollegeMetadata == null)
            throw new BusinessException(AccountCollegeMetadatasBusinessMessages.AccountCollegeMetadataNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountCollegeMetadataIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountCollegeMetadata? accountCollegeMetadata = await _accountCollegeMetadataRepository.GetAsync(
            predicate: acm => acm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountCollegeMetadataShouldExistWhenSelected(accountCollegeMetadata);
    }

    public async Task AccountCollegeMetadataGraduationYearMustBeOlderThanStartingYear(AccountCollegeMetadata accountCollegeMetadata)
    {
        if (accountCollegeMetadata.GraduationYear <= accountCollegeMetadata.StartingYear)
            throw new BusinessException(AccountCollegeMetadatasBusinessMessages.AccountCollegeMetadataGraduationYearMustBeOlderThanStartingYear);

        await Task.CompletedTask;
    }



}