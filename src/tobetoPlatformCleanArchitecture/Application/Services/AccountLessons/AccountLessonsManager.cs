using Application.Features.AccountLessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountLessons;

public class AccountLessonsManager : IAccountLessonsService
{
    private readonly IAccountLessonRepository _accountLessonRepository;
    private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

    public AccountLessonsManager(IAccountLessonRepository accountLessonRepository, AccountLessonBusinessRules accountLessonBusinessRules)
    {
        _accountLessonRepository = accountLessonRepository;
        _accountLessonBusinessRules = accountLessonBusinessRules;
    }

    public async Task<AccountLesson?> GetAsync(
        Expression<Func<AccountLesson, bool>> predicate,
        Func<IQueryable<AccountLesson>, IIncludableQueryable<AccountLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountLesson;
    }

    public async Task<IPaginate<AccountLesson>?> GetListAsync(
        Expression<Func<AccountLesson, bool>>? predicate = null,
        Func<IQueryable<AccountLesson>, IOrderedQueryable<AccountLesson>>? orderBy = null,
        Func<IQueryable<AccountLesson>, IIncludableQueryable<AccountLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountLesson> accountLessonList = await _accountLessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountLessonList;
    }

    public async Task<AccountLesson> AddAsync(AccountLesson accountLesson)
    {
        AccountLesson addedAccountLesson = await _accountLessonRepository.AddAsync(accountLesson);

        return addedAccountLesson;
    }

    public async Task<AccountLesson> UpdateAsync(AccountLesson accountLesson)
    {
        AccountLesson updatedAccountLesson = await _accountLessonRepository.UpdateAsync(accountLesson);

        return updatedAccountLesson;
    }

    public async Task<AccountLesson> DeleteAsync(AccountLesson accountLesson, bool permanent = false)
    {
        AccountLesson deletedAccountLesson = await _accountLessonRepository.DeleteAsync(accountLesson);

        return deletedAccountLesson;
    }
}
