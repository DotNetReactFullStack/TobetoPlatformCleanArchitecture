using Application.Features.AccountSocialMediaPlatforms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountSocialMediaPlatforms.Rules;

public class AccountSocialMediaPlatformBusinessRules : BaseBusinessRules
{
    private readonly IAccountSocialMediaPlatformRepository _accountSocialMediaPlatformRepository;

    public AccountSocialMediaPlatformBusinessRules(IAccountSocialMediaPlatformRepository accountSocialMediaPlatformRepository)
    {
        _accountSocialMediaPlatformRepository = accountSocialMediaPlatformRepository;
    }

    public Task AccountSocialMediaPlatformShouldExistWhenSelected(AccountSocialMediaPlatform? accountSocialMediaPlatform)
    {
        if (accountSocialMediaPlatform == null)
            throw new BusinessException(AccountSocialMediaPlatformsBusinessMessages.AccountSocialMediaPlatformNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountSocialMediaPlatformIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountSocialMediaPlatform? accountSocialMediaPlatform = await _accountSocialMediaPlatformRepository.GetAsync(
            predicate: asmp => asmp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountSocialMediaPlatformShouldExistWhenSelected(accountSocialMediaPlatform);
    }

    public Task AccountCanHasMaximumThreeSocialMediaPlatforms(AccountSocialMediaPlatform accountSocialMediaPlatform)
    {
        var accountSocialMediaPlatformCounts = _accountSocialMediaPlatformRepository.GetList(a=>a.AccountId == accountSocialMediaPlatform.AccountId).Count;

        if (accountSocialMediaPlatformCounts > 2)
            throw new BusinessException(AccountSocialMediaPlatformsBusinessMessages.AccountCanHasMaximumThreeSocialMediaPlatforms);
        return Task.CompletedTask;
    } 
}