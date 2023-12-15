using Application.Features.GraduationStatuses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GraduationStatuses;

public class GraduationStatusesManager : IGraduationStatusesService
{
    private readonly IGraduationStatusRepository _graduationStatusRepository;
    private readonly GraduationStatusBusinessRules _graduationStatusBusinessRules;

    public GraduationStatusesManager(IGraduationStatusRepository graduationStatusRepository, GraduationStatusBusinessRules graduationStatusBusinessRules)
    {
        _graduationStatusRepository = graduationStatusRepository;
        _graduationStatusBusinessRules = graduationStatusBusinessRules;
    }

    public async Task<GraduationStatus?> GetAsync(
        Expression<Func<GraduationStatus, bool>> predicate,
        Func<IQueryable<GraduationStatus>, IIncludableQueryable<GraduationStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GraduationStatus? graduationStatus = await _graduationStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return graduationStatus;
    }

    public async Task<IPaginate<GraduationStatus>?> GetListAsync(
        Expression<Func<GraduationStatus, bool>>? predicate = null,
        Func<IQueryable<GraduationStatus>, IOrderedQueryable<GraduationStatus>>? orderBy = null,
        Func<IQueryable<GraduationStatus>, IIncludableQueryable<GraduationStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GraduationStatus> graduationStatusList = await _graduationStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return graduationStatusList;
    }

    public async Task<GraduationStatus> AddAsync(GraduationStatus graduationStatus)
    {
        GraduationStatus addedGraduationStatus = await _graduationStatusRepository.AddAsync(graduationStatus);

        return addedGraduationStatus;
    }

    public async Task<GraduationStatus> UpdateAsync(GraduationStatus graduationStatus)
    {
        GraduationStatus updatedGraduationStatus = await _graduationStatusRepository.UpdateAsync(graduationStatus);

        return updatedGraduationStatus;
    }

    public async Task<GraduationStatus> DeleteAsync(GraduationStatus graduationStatus, bool permanent = false)
    {
        GraduationStatus deletedGraduationStatus = await _graduationStatusRepository.DeleteAsync(graduationStatus);

        return deletedGraduationStatus;
    }
}
