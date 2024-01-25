using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseDetails;

public interface IRecourseDetailsService
{
    Task<RecourseDetail?> GetAsync(
        Expression<Func<RecourseDetail, bool>> predicate,
        Func<IQueryable<RecourseDetail>, IIncludableQueryable<RecourseDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RecourseDetail>?> GetListAsync(
        Expression<Func<RecourseDetail, bool>>? predicate = null,
        Func<IQueryable<RecourseDetail>, IOrderedQueryable<RecourseDetail>>? orderBy = null,
        Func<IQueryable<RecourseDetail>, IIncludableQueryable<RecourseDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RecourseDetail> AddAsync(RecourseDetail recourseDetail);
    Task<RecourseDetail> UpdateAsync(RecourseDetail recourseDetail);
    Task<RecourseDetail> DeleteAsync(RecourseDetail recourseDetail, bool permanent = false);
}
