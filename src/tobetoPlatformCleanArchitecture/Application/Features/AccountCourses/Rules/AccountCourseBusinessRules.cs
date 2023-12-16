using Application.Features.AccountCourses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountCourses.Rules;

public class AccountCourseBusinessRules : BaseBusinessRules
{
    private readonly IAccountCourseRepository _accountCourseRepository;

    public AccountCourseBusinessRules(IAccountCourseRepository accountCourseRepository)
    {
        _accountCourseRepository = accountCourseRepository;
    }

    public Task AccountCourseShouldExistWhenSelected(AccountCourse? accountCourse)
    {
        if (accountCourse == null)
            throw new BusinessException(AccountCoursesBusinessMessages.AccountCourseNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountCourseIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountCourse? accountCourse = await _accountCourseRepository.GetAsync(
            predicate: ac => ac.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountCourseShouldExistWhenSelected(accountCourse);
    }
}