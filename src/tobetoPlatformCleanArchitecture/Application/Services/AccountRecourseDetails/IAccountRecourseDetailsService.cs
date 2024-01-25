using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AccountRecourseDetails;

public interface IAccountRecourseDetailsService
{
    Task<AccountRecourseDetail?> GetAsync(
        Expression<Func<AccountRecourseDetail, bool>> predicate,
        Func<IQueryable<AccountRecourseDetail>, IIncludableQueryable<AccountRecourseDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AccountRecourseDetail>?> GetListAsync(
        Expression<Func<AccountRecourseDetail, bool>>? predicate = null,
        Func<IQueryable<AccountRecourseDetail>, IOrderedQueryable<AccountRecourseDetail>>? orderBy = null,
        Func<IQueryable<AccountRecourseDetail>, IIncludableQueryable<AccountRecourseDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AccountRecourseDetail> AddAsync(AccountRecourseDetail accountRecourseDetail);
    Task<AccountRecourseDetail> UpdateAsync(AccountRecourseDetail accountRecourseDetail);
    Task<AccountRecourseDetail> DeleteAsync(AccountRecourseDetail accountRecourseDetail, bool permanent = false);
}
