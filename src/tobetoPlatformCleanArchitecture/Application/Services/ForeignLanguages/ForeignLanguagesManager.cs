using Application.Features.ForeignLanguages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ForeignLanguages;

public class ForeignLanguagesManager : IForeignLanguagesService
{
    private readonly IForeignLanguageRepository _foreignLanguageRepository;
    private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

    public ForeignLanguagesManager(IForeignLanguageRepository foreignLanguageRepository, ForeignLanguageBusinessRules foreignLanguageBusinessRules)
    {
        _foreignLanguageRepository = foreignLanguageRepository;
        _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
    }

    public async Task<ForeignLanguage?> GetAsync(
        Expression<Func<ForeignLanguage, bool>> predicate,
        Func<IQueryable<ForeignLanguage>, IIncludableQueryable<ForeignLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ForeignLanguage? foreignLanguage = await _foreignLanguageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return foreignLanguage;
    }

    public async Task<IPaginate<ForeignLanguage>?> GetListAsync(
        Expression<Func<ForeignLanguage, bool>>? predicate = null,
        Func<IQueryable<ForeignLanguage>, IOrderedQueryable<ForeignLanguage>>? orderBy = null,
        Func<IQueryable<ForeignLanguage>, IIncludableQueryable<ForeignLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ForeignLanguage> foreignLanguageList = await _foreignLanguageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return foreignLanguageList;
    }

    public async Task<ForeignLanguage> AddAsync(ForeignLanguage foreignLanguage)
    {
        ForeignLanguage addedForeignLanguage = await _foreignLanguageRepository.AddAsync(foreignLanguage);

        return addedForeignLanguage;
    }

    public async Task<ForeignLanguage> UpdateAsync(ForeignLanguage foreignLanguage)
    {
        ForeignLanguage updatedForeignLanguage = await _foreignLanguageRepository.UpdateAsync(foreignLanguage);

        return updatedForeignLanguage;
    }

    public async Task<ForeignLanguage> DeleteAsync(ForeignLanguage foreignLanguage, bool permanent = false)
    {
        ForeignLanguage deletedForeignLanguage = await _foreignLanguageRepository.DeleteAsync(foreignLanguage);

        return deletedForeignLanguage;
    }
}
