using Application.Features.AccountCourses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCourses;

public class AccountCoursesManager : IAccountCoursesService
{
    private readonly IAccountCourseRepository _accountCourseRepository;
    private readonly AccountCourseBusinessRules _accountCourseBusinessRules;

    public AccountCoursesManager(IAccountCourseRepository accountCourseRepository, AccountCourseBusinessRules accountCourseBusinessRules)
    {
        _accountCourseRepository = accountCourseRepository;
        _accountCourseBusinessRules = accountCourseBusinessRules;
    }

    public async Task<AccountCourse?> GetAsync(
        Expression<Func<AccountCourse, bool>> predicate,
        Func<IQueryable<AccountCourse>, IIncludableQueryable<AccountCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountCourse? accountCourse = await _accountCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountCourse;
    }

    public async Task<IPaginate<AccountCourse>?> GetListAsync(
        Expression<Func<AccountCourse, bool>>? predicate = null,
        Func<IQueryable<AccountCourse>, IOrderedQueryable<AccountCourse>>? orderBy = null,
        Func<IQueryable<AccountCourse>, IIncludableQueryable<AccountCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountCourse> accountCourseList = await _accountCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountCourseList;
    }

    public async Task<AccountCourse> AddAsync(AccountCourse accountCourse)
    {
        AccountCourse addedAccountCourse = await _accountCourseRepository.AddAsync(accountCourse);

        return addedAccountCourse;
    }

    public async Task<AccountCourse> UpdateAsync(AccountCourse accountCourse)
    {
        AccountCourse updatedAccountCourse = await _accountCourseRepository.UpdateAsync(accountCourse);

        return updatedAccountCourse;
    }

    public async Task<AccountCourse> DeleteAsync(AccountCourse accountCourse, bool permanent = false)
    {
        AccountCourse deletedAccountCourse = await _accountCourseRepository.DeleteAsync(accountCourse);

        return deletedAccountCourse;
    }
}
