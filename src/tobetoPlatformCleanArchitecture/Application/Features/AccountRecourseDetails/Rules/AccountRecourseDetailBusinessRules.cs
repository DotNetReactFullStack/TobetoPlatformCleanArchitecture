using Application.Features.AccountRecourseDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountRecourseDetails.Rules;

public class AccountRecourseDetailBusinessRules : BaseBusinessRules
{
    private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;

    public AccountRecourseDetailBusinessRules(IAccountRecourseDetailRepository accountRecourseDetailRepository)
    {
        _accountRecourseDetailRepository = accountRecourseDetailRepository;
    }

    public Task AccountRecourseDetailShouldExistWhenSelected(AccountRecourseDetail? accountRecourseDetail)
    {
        if (accountRecourseDetail == null)
            throw new BusinessException(AccountRecourseDetailsBusinessMessages.AccountRecourseDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountRecourseDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountRecourseDetail? accountRecourseDetail = await _accountRecourseDetailRepository.GetAsync(
            predicate: ard => ard.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountRecourseDetailShouldExistWhenSelected(accountRecourseDetail);
    }
}