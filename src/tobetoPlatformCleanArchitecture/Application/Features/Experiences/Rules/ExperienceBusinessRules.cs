using Application.Features.Experiences.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Experiences.Rules;

public class ExperienceBusinessRules : BaseBusinessRules
{
    private readonly IExperienceRepository _experienceRepository;

    public ExperienceBusinessRules(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public Task ExperienceShouldExistWhenSelected(Experience? experience)
    {
        if (experience == null)
            throw new BusinessException(ExperiencesBusinessMessages.ExperienceNotExists);
        return Task.CompletedTask;
    }

    public async Task ExperienceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Experience? experience = await _experienceRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExperienceShouldExistWhenSelected(experience);
    }
}