using Application.Features.AccountClassrooms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountClassrooms;

public class AccountClassroomsManager : IAccountClassroomsService
{
    private readonly IAccountClassroomRepository _accountClassroomRepository;
    private readonly AccountClassroomBusinessRules _accountClassroomBusinessRules;

    public AccountClassroomsManager(IAccountClassroomRepository accountClassroomRepository, AccountClassroomBusinessRules accountClassroomBusinessRules)
    {
        _accountClassroomRepository = accountClassroomRepository;
        _accountClassroomBusinessRules = accountClassroomBusinessRules;
    }

    public async Task<AccountClassroom?> GetAsync(
        Expression<Func<AccountClassroom, bool>> predicate,
        Func<IQueryable<AccountClassroom>, IIncludableQueryable<AccountClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AccountClassroom? accountClassroom = await _accountClassroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return accountClassroom;
    }

    public async Task<IPaginate<AccountClassroom>?> GetListAsync(
        Expression<Func<AccountClassroom, bool>>? predicate = null,
        Func<IQueryable<AccountClassroom>, IOrderedQueryable<AccountClassroom>>? orderBy = null,
        Func<IQueryable<AccountClassroom>, IIncludableQueryable<AccountClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AccountClassroom> accountClassroomList = await _accountClassroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return accountClassroomList;
    }

    public async Task<AccountClassroom> AddAsync(AccountClassroom accountClassroom)
    {
        AccountClassroom addedAccountClassroom = await _accountClassroomRepository.AddAsync(accountClassroom);

        return addedAccountClassroom;
    }

    public async Task<AccountClassroom> UpdateAsync(AccountClassroom accountClassroom)
    {
        AccountClassroom updatedAccountClassroom = await _accountClassroomRepository.UpdateAsync(accountClassroom);

        return updatedAccountClassroom;
    }

    public async Task<AccountClassroom> DeleteAsync(AccountClassroom accountClassroom, bool permanent = false)
    {
        AccountClassroom deletedAccountClassroom = await _accountClassroomRepository.DeleteAsync(accountClassroom);

        return deletedAccountClassroom;
    }
}
