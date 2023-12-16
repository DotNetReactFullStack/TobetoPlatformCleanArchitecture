using Application.Features.AccountLessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountLessons.Rules;

public class AccountLessonBusinessRules : BaseBusinessRules
{
    private readonly IAccountLessonRepository _accountLessonRepository;

    public AccountLessonBusinessRules(IAccountLessonRepository accountLessonRepository)
    {
        _accountLessonRepository = accountLessonRepository;
    }

    public Task AccountLessonShouldExistWhenSelected(AccountLesson? accountLesson)
    {
        if (accountLesson == null)
            throw new BusinessException(AccountLessonsBusinessMessages.AccountLessonNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountLessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(
            predicate: al => al.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountLessonShouldExistWhenSelected(accountLesson);
    }
}