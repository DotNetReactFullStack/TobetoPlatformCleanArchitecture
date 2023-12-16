using Application.Features.AccountClassrooms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountClassrooms.Rules;

public class AccountClassroomBusinessRules : BaseBusinessRules
{
    private readonly IAccountClassroomRepository _accountClassroomRepository;

    public AccountClassroomBusinessRules(IAccountClassroomRepository accountClassroomRepository)
    {
        _accountClassroomRepository = accountClassroomRepository;
    }

    public Task AccountClassroomShouldExistWhenSelected(AccountClassroom? accountClassroom)
    {
        if (accountClassroom == null)
            throw new BusinessException(AccountClassroomsBusinessMessages.AccountClassroomNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountClassroom? accountClassroom = await _accountClassroomRepository.GetAsync(
            predicate: ac => ac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountClassroomShouldExistWhenSelected(accountClassroom);
    }
}