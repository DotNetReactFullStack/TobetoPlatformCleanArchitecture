using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyTypes;

public interface ISurveyTypesService
{
    Task<SurveyType?> GetAsync(
        Expression<Func<SurveyType, bool>> predicate,
        Func<IQueryable<SurveyType>, IIncludableQueryable<SurveyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SurveyType>?> GetListAsync(
        Expression<Func<SurveyType, bool>>? predicate = null,
        Func<IQueryable<SurveyType>, IOrderedQueryable<SurveyType>>? orderBy = null,
        Func<IQueryable<SurveyType>, IIncludableQueryable<SurveyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SurveyType> AddAsync(SurveyType surveyType);
    Task<SurveyType> UpdateAsync(SurveyType surveyType);
    Task<SurveyType> DeleteAsync(SurveyType surveyType, bool permanent = false);
}
