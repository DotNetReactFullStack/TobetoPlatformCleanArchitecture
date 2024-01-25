using Application.Features.GraduationStatus.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.GraduationStatus.Rules;

public class GraduationStatusBusinessRules : BaseBusinessRules
{
    private readonly IGraduationStatusRepository _graduationStatusRepository;

    public GraduationStatusBusinessRules(IGraduationStatusRepository graduationStatusRepository)
    {
        _graduationStatusRepository = graduationStatusRepository;
    }

    public Task GraduationStatusShouldExistWhenSelected(GraduationStatus? graduationStatus)
    {
        if (graduationStatus == null)
            throw new BusinessException(GraduationStatusBusinessMessages.GraduationStatusNotExists);
        return Task.CompletedTask;
    }

    public async Task GraduationStatusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        GraduationStatus? graduationStatus = await _graduationStatusRepository.GetAsync(
            predicate: gs => gs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GraduationStatusShouldExistWhenSelected(graduationStatus);
    }
}