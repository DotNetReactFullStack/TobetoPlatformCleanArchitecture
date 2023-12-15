using Application.Features.ForeignLanguages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ForeignLanguages.Rules;

public class ForeignLanguageBusinessRules : BaseBusinessRules
{
    private readonly IForeignLanguageRepository _foreignLanguageRepository;

    public ForeignLanguageBusinessRules(IForeignLanguageRepository foreignLanguageRepository)
    {
        _foreignLanguageRepository = foreignLanguageRepository;
    }

    public Task ForeignLanguageShouldExistWhenSelected(ForeignLanguage? foreignLanguage)
    {
        if (foreignLanguage == null)
            throw new BusinessException(ForeignLanguagesBusinessMessages.ForeignLanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task ForeignLanguageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ForeignLanguage? foreignLanguage = await _foreignLanguageRepository.GetAsync(
            predicate: fl => fl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ForeignLanguageShouldExistWhenSelected(foreignLanguage);
    }
}