using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Experiences;

public class ExperiencesManager : IExperiencesService
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly ExperienceBusinessRules _experienceBusinessRules;

    public ExperiencesManager(IExperienceRepository experienceRepository, ExperienceBusinessRules experienceBusinessRules)
    {
        _experienceRepository = experienceRepository;
        _experienceBusinessRules = experienceBusinessRules;
    }

    public async Task<Experience?> GetAsync(
        Expression<Func<Experience, bool>> predicate,
        Func<IQueryable<Experience>, IIncludableQueryable<Experience, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Experience? experience = await _experienceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return experience;
    }

    public async Task<IPaginate<Experience>?> GetListAsync(
        Expression<Func<Experience, bool>>? predicate = null,
        Func<IQueryable<Experience>, IOrderedQueryable<Experience>>? orderBy = null,
        Func<IQueryable<Experience>, IIncludableQueryable<Experience, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Experience> experienceList = await _experienceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return experienceList;
    }

    public async Task<Experience> AddAsync(Experience experience)
    {
        Experience addedExperience = await _experienceRepository.AddAsync(experience);

        return addedExperience;
    }

    public async Task<Experience> UpdateAsync(Experience experience)
    {
        Experience updatedExperience = await _experienceRepository.UpdateAsync(experience);

        return updatedExperience;
    }

    public async Task<Experience> DeleteAsync(Experience experience, bool permanent = false)
    {
        Experience deletedExperience = await _experienceRepository.DeleteAsync(experience);

        return deletedExperience;
    }
}
