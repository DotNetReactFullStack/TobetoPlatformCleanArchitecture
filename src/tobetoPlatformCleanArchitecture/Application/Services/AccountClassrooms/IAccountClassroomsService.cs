using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountClassrooms;

public interface IAccountClassroomsService
{
    Task<AccountClassroom?> GetAsync(
        Expression<Func<AccountClassroom, bool>> predicate,
        Func<IQueryable<AccountClassroom>, IIncludableQueryable<AccountClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountClassroom>?> GetListAsync(
        Expression<Func<AccountClassroom, bool>>? predicate = null,
        Func<IQueryable<AccountClassroom>, IOrderedQueryable<AccountClassroom>>? orderBy = null,
        Func<IQueryable<AccountClassroom>, IIncludableQueryable<AccountClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountClassroom> AddAsync(AccountClassroom accountClassroom);
    Task<AccountClassroom> UpdateAsync(AccountClassroom accountClassroom);
    Task<AccountClassroom> DeleteAsync(AccountClassroom accountClassroom, bool permanent = false);
}
