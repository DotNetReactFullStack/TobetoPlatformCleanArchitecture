using Application.Features.AccountExamResults.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountExamResults.Rules;

public class AccountExamResultBusinessRules : BaseBusinessRules
{
    private readonly IAccountExamResultRepository _accountExamResultRepository;

    public AccountExamResultBusinessRules(IAccountExamResultRepository accountExamResultRepository)
    {
        _accountExamResultRepository = accountExamResultRepository;
    }

    public Task AccountExamResultShouldExistWhenSelected(AccountExamResult? accountExamResult)
    {
        if (accountExamResult == null)
            throw new BusinessException(AccountExamResultsBusinessMessages.AccountExamResultNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountExamResultIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountExamResult? accountExamResult = await _accountExamResultRepository.GetAsync(
            predicate: aer => aer.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountExamResultShouldExistWhenSelected(accountExamResult);
    }
}