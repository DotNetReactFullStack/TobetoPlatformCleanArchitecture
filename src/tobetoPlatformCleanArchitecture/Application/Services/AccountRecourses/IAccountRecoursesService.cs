using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountRecourses;

public interface IAccountRecoursesService
{
    Task<AccountRecourse?> GetAsync(
        Expression<Func<AccountRecourse, bool>> predicate,
        Func<IQueryable<AccountRecourse>, IIncludableQueryable<AccountRecourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountRecourse>?> GetListAsync(
        Expression<Func<AccountRecourse, bool>>? predicate = null,
        Func<IQueryable<AccountRecourse>, IOrderedQueryable<AccountRecourse>>? orderBy = null,
        Func<IQueryable<AccountRecourse>, IIncludableQueryable<AccountRecourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountRecourse> AddAsync(AccountRecourse accountRecourse);
    Task<AccountRecourse> UpdateAsync(AccountRecourse accountRecourse);
    Task<AccountRecourse> DeleteAsync(AccountRecourse accountRecourse, bool permanent = false);
}
