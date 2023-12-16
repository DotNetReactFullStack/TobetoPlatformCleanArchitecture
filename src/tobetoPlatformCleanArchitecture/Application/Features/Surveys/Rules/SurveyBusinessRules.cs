using Application.Features.Surveys.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Surveys.Rules;

public class SurveyBusinessRules : BaseBusinessRules
{
    private readonly ISurveyRepository _surveyRepository;

    public SurveyBusinessRules(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public Task SurveyShouldExistWhenSelected(Survey? survey)
    {
        if (survey == null)
            throw new BusinessException(SurveysBusinessMessages.SurveyNotExists);
        return Task.CompletedTask;
    }

    public async Task SurveyIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyShouldExistWhenSelected(survey);
    }
}