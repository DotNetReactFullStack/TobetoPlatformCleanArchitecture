using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Surveys;

public interface ISurveysService
{
    Task<Survey?> GetAsync(
        Expression<Func<Survey, bool>> predicate,
        Func<IQueryable<Survey>, IIncludableQueryable<Survey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Survey>?> GetListAsync(
        Expression<Func<Survey, bool>>? predicate = null,
        Func<IQueryable<Survey>, IOrderedQueryable<Survey>>? orderBy = null,
        Func<IQueryable<Survey>, IIncludableQueryable<Survey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Survey> AddAsync(Survey survey);
    Task<Survey> UpdateAsync(Survey survey);
    Task<Survey> DeleteAsync(Survey survey, bool permanent = false);
}
