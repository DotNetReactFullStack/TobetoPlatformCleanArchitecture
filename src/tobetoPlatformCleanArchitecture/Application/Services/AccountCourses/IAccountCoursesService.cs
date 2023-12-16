using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountCourses;

public interface IAccountCoursesService
{
    Task<AccountCourse?> GetAsync(
        Expression<Func<AccountCourse, bool>> predicate,
        Func<IQueryable<AccountCourse>, IIncludableQueryable<AccountCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountCourse>?> GetListAsync(
        Expression<Func<AccountCourse, bool>>? predicate = null,
        Func<IQueryable<AccountCourse>, IOrderedQueryable<AccountCourse>>? orderBy = null,
        Func<IQueryable<AccountCourse>, IIncludableQueryable<AccountCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountCourse> AddAsync(AccountCourse accountCourse);
    Task<AccountCourse> UpdateAsync(AccountCourse accountCourse);
    Task<AccountCourse> DeleteAsync(AccountCourse accountCourse, bool permanent = false);
}
