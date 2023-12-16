using Application.Features.AccountLearningPaths.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountLearningPaths.Rules;

public class AccountLearningPathBusinessRules : BaseBusinessRules
{
    private readonly IAccountLearningPathRepository _accountLearningPathRepository;

    public AccountLearningPathBusinessRules(IAccountLearningPathRepository accountLearningPathRepository)
    {
        _accountLearningPathRepository = accountLearningPathRepository;
    }

    public Task AccountLearningPathShouldExistWhenSelected(AccountLearningPath? accountLearningPath)
    {
        if (accountLearningPath == null)
            throw new BusinessException(AccountLearningPathsBusinessMessages.AccountLearningPathNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountLearningPathIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(
            predicate: alp => alp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountLearningPathShouldExistWhenSelected(accountLearningPath);
    }
}