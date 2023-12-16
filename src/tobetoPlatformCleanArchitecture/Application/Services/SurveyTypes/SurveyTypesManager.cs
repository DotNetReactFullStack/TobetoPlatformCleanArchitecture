using Application.Features.SurveyTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SurveyTypes;

public class SurveyTypesManager : ISurveyTypesService
{
    private readonly ISurveyTypeRepository _surveyTypeRepository;
    private readonly SurveyTypeBusinessRules _surveyTypeBusinessRules;

    public SurveyTypesManager(ISurveyTypeRepository surveyTypeRepository, SurveyTypeBusinessRules surveyTypeBusinessRules)
    {
        _surveyTypeRepository = surveyTypeRepository;
        _surveyTypeBusinessRules = surveyTypeBusinessRules;
    }

    public async Task<SurveyType?> GetAsync(
        Expression<Func<SurveyType, bool>> predicate,
        Func<IQueryable<SurveyType>, IIncludableQueryable<SurveyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SurveyType? surveyType = await _surveyTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return surveyType;
    }

    public async Task<IPaginate<SurveyType>?> GetListAsync(
        Expression<Func<SurveyType, bool>>? predicate = null,
        Func<IQueryable<SurveyType>, IOrderedQueryable<SurveyType>>? orderBy = null,
        Func<IQueryable<SurveyType>, IIncludableQueryable<SurveyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SurveyType> surveyTypeList = await _surveyTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return surveyTypeList;
    }

    public async Task<SurveyType> AddAsync(SurveyType surveyType)
    {
        SurveyType addedSurveyType = await _surveyTypeRepository.AddAsync(surveyType);

        return addedSurveyType;
    }

    public async Task<SurveyType> UpdateAsync(SurveyType surveyType)
    {
        SurveyType updatedSurveyType = await _surveyTypeRepository.UpdateAsync(surveyType);

        return updatedSurveyType;
    }

    public async Task<SurveyType> DeleteAsync(SurveyType surveyType, bool permanent = false)
    {
        SurveyType deletedSurveyType = await _surveyTypeRepository.DeleteAsync(surveyType);

        return deletedSurveyType;
    }
}
