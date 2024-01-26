using Application.Features.RecourseDetails.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseDetails;

public class RecourseDetailsManager : IRecourseDetailsService
{
    private readonly IRecourseDetailRepository _recourseDetailRepository;
    private readonly RecourseDetailBusinessRules _recourseDetailBusinessRules;

    public RecourseDetailsManager(IRecourseDetailRepository recourseDetailRepository, RecourseDetailBusinessRules recourseDetailBusinessRules)
    {
        _recourseDetailRepository = recourseDetailRepository;
        _recourseDetailBusinessRules = recourseDetailBusinessRules;
    }

    public async Task<RecourseDetail?> GetAsync(
        Expression<Func<RecourseDetail, bool>> predicate,
        Func<IQueryable<RecourseDetail>, IIncludableQueryable<RecourseDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RecourseDetail? recourseDetail = await _recourseDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return recourseDetail;
    }

    public async Task<IPaginate<RecourseDetail>?> GetListAsync(
        Expression<Func<RecourseDetail, bool>>? predicate = null,
        Func<IQueryable<RecourseDetail>, IOrderedQueryable<RecourseDetail>>? orderBy = null,
        Func<IQueryable<RecourseDetail>, IIncludableQueryable<RecourseDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RecourseDetail> recourseDetailList = await _recourseDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return recourseDetailList;
    }

    public async Task<RecourseDetail> AddAsync(RecourseDetail recourseDetail)
    {
        RecourseDetail addedRecourseDetail = await _recourseDetailRepository.AddAsync(recourseDetail);

        return addedRecourseDetail;
    }

    public async Task<RecourseDetail> UpdateAsync(RecourseDetail recourseDetail)
    {
        RecourseDetail updatedRecourseDetail = await _recourseDetailRepository.UpdateAsync(recourseDetail);

        return updatedRecourseDetail;
    }

    public async Task<RecourseDetail> DeleteAsync(RecourseDetail recourseDetail, bool permanent = false)
    {
        RecourseDetail deletedRecourseDetail = await _recourseDetailRepository.DeleteAsync(recourseDetail);

        return deletedRecourseDetail;
    }
}
