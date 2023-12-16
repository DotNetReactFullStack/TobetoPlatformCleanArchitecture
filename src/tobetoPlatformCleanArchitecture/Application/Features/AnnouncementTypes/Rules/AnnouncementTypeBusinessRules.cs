using Application.Features.AnnouncementTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AnnouncementTypes.Rules;

public class AnnouncementTypeBusinessRules : BaseBusinessRules
{
    private readonly IAnnouncementTypeRepository _announcementTypeRepository;

    public AnnouncementTypeBusinessRules(IAnnouncementTypeRepository announcementTypeRepository)
    {
        _announcementTypeRepository = announcementTypeRepository;
    }

    public Task AnnouncementTypeShouldExistWhenSelected(AnnouncementType? announcementType)
    {
        if (announcementType == null)
            throw new BusinessException(AnnouncementTypesBusinessMessages.AnnouncementTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task AnnouncementTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(
            predicate: at => at.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AnnouncementTypeShouldExistWhenSelected(announcementType);
    }
}