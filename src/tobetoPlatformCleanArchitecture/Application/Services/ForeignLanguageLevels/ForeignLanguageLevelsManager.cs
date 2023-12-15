using Application.Features.ForeignLanguageLevels.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ForeignLanguageLevels;

public class ForeignLanguageLevelsManager : IForeignLanguageLevelsService
{
    private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
    private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

    public ForeignLanguageLevelsManager(IForeignLanguageLevelRepository foreignLanguageLevelRepository, ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
    {
        _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
        _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
    }

    public async Task<ForeignLanguageLevel?> GetAsync(
        Expression<Func<ForeignLanguageLevel, bool>> predicate,
        Func<IQueryable<ForeignLanguageLevel>, IIncludableQueryable<ForeignLanguageLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ForeignLanguageLevel? foreignLanguageLevel = await _foreignLanguageLevelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return foreignLanguageLevel;
    }

    public async Task<IPaginate<ForeignLanguageLevel>?> GetListAsync(
        Expression<Func<ForeignLanguageLevel, bool>>? predicate = null,
        Func<IQueryable<ForeignLanguageLevel>, IOrderedQueryable<ForeignLanguageLevel>>? orderBy = null,
        Func<IQueryable<ForeignLanguageLevel>, IIncludableQueryable<ForeignLanguageLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ForeignLanguageLevel> foreignLanguageLevelList = await _foreignLanguageLevelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return foreignLanguageLevelList;
    }

    public async Task<ForeignLanguageLevel> AddAsync(ForeignLanguageLevel foreignLanguageLevel)
    {
        ForeignLanguageLevel addedForeignLanguageLevel = await _foreignLanguageLevelRepository.AddAsync(foreignLanguageLevel);

        return addedForeignLanguageLevel;
    }

    public async Task<ForeignLanguageLevel> UpdateAsync(ForeignLanguageLevel foreignLanguageLevel)
    {
        ForeignLanguageLevel updatedForeignLanguageLevel = await _foreignLanguageLevelRepository.UpdateAsync(foreignLanguageLevel);

        return updatedForeignLanguageLevel;
    }

    public async Task<ForeignLanguageLevel> DeleteAsync(ForeignLanguageLevel foreignLanguageLevel, bool permanent = false)
    {
        ForeignLanguageLevel deletedForeignLanguageLevel = await _foreignLanguageLevelRepository.DeleteAsync(foreignLanguageLevel);

        return deletedForeignLanguageLevel;
    }
}
