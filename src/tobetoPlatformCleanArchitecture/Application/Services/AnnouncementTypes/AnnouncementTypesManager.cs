using Application.Features.AnnouncementTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AnnouncementTypes;

public class AnnouncementTypesManager : IAnnouncementTypesService
{
    private readonly IAnnouncementTypeRepository _announcementTypeRepository;
    private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

    public AnnouncementTypesManager(IAnnouncementTypeRepository announcementTypeRepository, AnnouncementTypeBusinessRules announcementTypeBusinessRules)
    {
        _announcementTypeRepository = announcementTypeRepository;
        _announcementTypeBusinessRules = announcementTypeBusinessRules;
    }

    public async Task<AnnouncementType?> GetAsync(
        Expression<Func<AnnouncementType, bool>> predicate,
        Func<IQueryable<AnnouncementType>, IIncludableQueryable<AnnouncementType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return announcementType;
    }

    public async Task<IPaginate<AnnouncementType>?> GetListAsync(
        Expression<Func<AnnouncementType, bool>>? predicate = null,
        Func<IQueryable<AnnouncementType>, IOrderedQueryable<AnnouncementType>>? orderBy = null,
        Func<IQueryable<AnnouncementType>, IIncludableQueryable<AnnouncementType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AnnouncementType> announcementTypeList = await _announcementTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return announcementTypeList;
    }

    public async Task<AnnouncementType> AddAsync(AnnouncementType announcementType)
    {
        AnnouncementType addedAnnouncementType = await _announcementTypeRepository.AddAsync(announcementType);

        return addedAnnouncementType;
    }

    public async Task<AnnouncementType> UpdateAsync(AnnouncementType announcementType)
    {
        AnnouncementType updatedAnnouncementType = await _announcementTypeRepository.UpdateAsync(announcementType);

        return updatedAnnouncementType;
    }

    public async Task<AnnouncementType> DeleteAsync(AnnouncementType announcementType, bool permanent = false)
    {
        AnnouncementType deletedAnnouncementType = await _announcementTypeRepository.DeleteAsync(announcementType);

        return deletedAnnouncementType;
    }
}
