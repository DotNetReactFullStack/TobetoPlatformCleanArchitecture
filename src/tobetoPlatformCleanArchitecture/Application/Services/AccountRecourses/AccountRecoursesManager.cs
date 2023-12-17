using Application.Features.AccountRecourses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountRecourses;

public class AccountRecoursesManager : IAccountRecoursesService
{
    private readonly IAccountRecourseRepository _accountRecourseRepository;
    private readonly AccountRecourseBusinessRules _accountRecourseBusinessRules;

    public AccountRecoursesManager(IAccountRecourseRepository accountRecourseRepository, AccountRecourseBusinessRules accountRecourseBusinessRules)
    {
        _accountRecourseRepository = accountRecourseRepository;
        _accountRecourseBusinessRules = accountRecourseBusinessRules;
    }

    public async Task<AccountRecourse?> GetAsync(
        Expression<Func<AccountRecourse, bool>> predicate,
        Func<IQueryable<AccountRecourse>, IIncludableQueryable<AccountRecourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountRecourse? accountRecourse = await _accountRecourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountRecourse;
    }

    public async Task<IPaginate<AccountRecourse>?> GetListAsync(
        Expression<Func<AccountRecourse, bool>>? predicate = null,
        Func<IQueryable<AccountRecourse>, IOrderedQueryable<AccountRecourse>>? orderBy = null,
        Func<IQueryable<AccountRecourse>, IIncludableQueryable<AccountRecourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountRecourse> accountRecourseList = await _accountRecourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountRecourseList;
    }

    public async Task<AccountRecourse> AddAsync(AccountRecourse accountRecourse)
    {
        AccountRecourse addedAccountRecourse = await _accountRecourseRepository.AddAsync(accountRecourse);

        return addedAccountRecourse;
    }

    public async Task<AccountRecourse> UpdateAsync(AccountRecourse accountRecourse)
    {
        AccountRecourse updatedAccountRecourse = await _accountRecourseRepository.UpdateAsync(accountRecourse);

        return updatedAccountRecourse;
    }

    public async Task<AccountRecourse> DeleteAsync(AccountRecourse accountRecourse, bool permanent = false)
    {
        AccountRecourse deletedAccountRecourse = await _accountRecourseRepository.DeleteAsync(accountRecourse);

        return deletedAccountRecourse;
    }
}
