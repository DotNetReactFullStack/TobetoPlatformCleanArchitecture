using Application.Features.AccountRecourses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountRecourses.Rules;

public class AccountRecourseBusinessRules : BaseBusinessRules
{
    private readonly IAccountRecourseRepository _accountRecourseRepository;

    public AccountRecourseBusinessRules(IAccountRecourseRepository accountRecourseRepository)
    {
        _accountRecourseRepository = accountRecourseRepository;
    }

    public Task AccountRecourseShouldExistWhenSelected(AccountRecourse? accountRecourse)
    {
        if (accountRecourse == null)
            throw new BusinessException(AccountRecoursesBusinessMessages.AccountRecourseNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountRecourseIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountRecourse? accountRecourse = await _accountRecourseRepository.GetAsync(
            predicate: ar => ar.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountRecourseShouldExistWhenSelected(accountRecourse);
    }
}