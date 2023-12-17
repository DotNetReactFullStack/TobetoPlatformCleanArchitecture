using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseSteps;

public interface IRecourseStepsService
{
    Task<RecourseStep?> GetAsync(
        Expression<Func<RecourseStep, bool>> predicate,
        Func<IQueryable<RecourseStep>, IIncludableQueryable<RecourseStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RecourseStep>?> GetListAsync(
        Expression<Func<RecourseStep, bool>>? predicate = null,
        Func<IQueryable<RecourseStep>, IOrderedQueryable<RecourseStep>>? orderBy = null,
        Func<IQueryable<RecourseStep>, IIncludableQueryable<RecourseStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RecourseStep> AddAsync(RecourseStep recourseStep);
    Task<RecourseStep> UpdateAsync(RecourseStep recourseStep);
    Task<RecourseStep> DeleteAsync(RecourseStep recourseStep, bool permanent = false);
}
