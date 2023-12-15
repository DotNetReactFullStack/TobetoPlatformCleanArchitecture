using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace Application.Services.GraduationStatuses;

public interface IGraduationStatusesService
{
    Task<GraduationStatus?> GetAsync(
        Expression<Func<GraduationStatus, bool>> predicate,
        Func<IQueryable<GraduationStatus>, IIncludableQueryable<GraduationStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GraduationStatus>?> GetListAsync(
        Expression<Func<GraduationStatus, bool>>? predicate = null,
        Func<IQueryable<GraduationStatus>, IOrderedQueryable<GraduationStatus>>? orderBy = null,
        Func<IQueryable<GraduationStatus>, IIncludableQueryable<GraduationStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GraduationStatus> AddAsync(GraduationStatus graduationStatus);
    Task<GraduationStatus> UpdateAsync(GraduationStatus graduationStatus);
    Task<GraduationStatus> DeleteAsync(GraduationStatus graduationStatus, bool permanent = false);
}
