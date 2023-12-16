using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Surveys;

public class SurveysManager : ISurveysService
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly SurveyBusinessRules _surveyBusinessRules;

    public SurveysManager(ISurveyRepository surveyRepository, SurveyBusinessRules surveyBusinessRules)
    {
        _surveyRepository = surveyRepository;
        _surveyBusinessRules = surveyBusinessRules;
    }

    public async Task<Survey?> GetAsync(
        Expression<Func<Survey, bool>> predicate,
        Func<IQueryable<Survey>, IIncludableQueryable<Survey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Survey? survey = await _surveyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return survey;
    }

    public async Task<IPaginate<Survey>?> GetListAsync(
        Expression<Func<Survey, bool>>? predicate = null,
        Func<IQueryable<Survey>, IOrderedQueryable<Survey>>? orderBy = null,
        Func<IQueryable<Survey>, IIncludableQueryable<Survey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Survey> surveyList = await _surveyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return surveyList;
    }

    public async Task<Survey> AddAsync(Survey survey)
    {
        Survey addedSurvey = await _surveyRepository.AddAsync(survey);

        return addedSurvey;
    }

    public async Task<Survey> UpdateAsync(Survey survey)
    {
        Survey updatedSurvey = await _surveyRepository.UpdateAsync(survey);

        return updatedSurvey;
    }

    public async Task<Survey> DeleteAsync(Survey survey, bool permanent = false)
    {
        Survey deletedSurvey = await _surveyRepository.DeleteAsync(survey);

        return deletedSurvey;
    }
}
