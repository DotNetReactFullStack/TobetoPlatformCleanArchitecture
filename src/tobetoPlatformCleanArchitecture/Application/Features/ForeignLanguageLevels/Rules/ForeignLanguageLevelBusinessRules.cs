using Application.Features.ForeignLanguageLevels.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ForeignLanguageLevels.Rules;

public class ForeignLanguageLevelBusinessRules : BaseBusinessRules
{
    private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;

    public ForeignLanguageLevelBusinessRules(IForeignLanguageLevelRepository foreignLanguageLevelRepository)
    {
        _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
    }

    public Task ForeignLanguageLevelShouldExistWhenSelected(ForeignLanguageLevel? foreignLanguageLevel)
    {
        if (foreignLanguageLevel == null)
            throw new BusinessException(ForeignLanguageLevelsBusinessMessages.ForeignLanguageLevelNotExists);
        return Task.CompletedTask;
    }

    public async Task ForeignLanguageLevelIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ForeignLanguageLevel? foreignLanguageLevel = await _foreignLanguageLevelRepository.GetAsync(
            predicate: fll => fll.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ForeignLanguageLevelShouldExistWhenSelected(foreignLanguageLevel);
    }
}