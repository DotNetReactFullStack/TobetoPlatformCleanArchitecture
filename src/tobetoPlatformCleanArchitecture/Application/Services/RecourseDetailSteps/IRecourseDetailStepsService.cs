using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseDetailSteps;

public interface IRecourseDetailStepsService
{
    Task<RecourseDetailStep?> GetAsync(
        Expression<Func<RecourseDetailStep, bool>> predicate,
        Func<IQueryable<RecourseDetailStep>, IIncludableQueryable<RecourseDetailStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RecourseDetailStep>?> GetListAsync(
        Expression<Func<RecourseDetailStep, bool>>? predicate = null,
        Func<IQueryable<RecourseDetailStep>, IOrderedQueryable<RecourseDetailStep>>? orderBy = null,
        Func<IQueryable<RecourseDetailStep>, IIncludableQueryable<RecourseDetailStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RecourseDetailStep> AddAsync(RecourseDetailStep recourseDetailStep);
    Task<RecourseDetailStep> UpdateAsync(RecourseDetailStep recourseDetailStep);
    Task<RecourseDetailStep> DeleteAsync(RecourseDetailStep recourseDetailStep, bool permanent = false);
}
