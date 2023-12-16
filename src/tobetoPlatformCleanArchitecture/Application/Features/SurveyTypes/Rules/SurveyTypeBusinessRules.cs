using Application.Features.SurveyTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SurveyTypes.Rules;

public class SurveyTypeBusinessRules : BaseBusinessRules
{
    private readonly ISurveyTypeRepository _surveyTypeRepository;

    public SurveyTypeBusinessRules(ISurveyTypeRepository surveyTypeRepository)
    {
        _surveyTypeRepository = surveyTypeRepository;
    }

    public Task SurveyTypeShouldExistWhenSelected(SurveyType? surveyType)
    {
        if (surveyType == null)
            throw new BusinessException(SurveyTypesBusinessMessages.SurveyTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task SurveyTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SurveyType? surveyType = await _surveyTypeRepository.GetAsync(
            predicate: st => st.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SurveyTypeShouldExistWhenSelected(surveyType);
    }
}