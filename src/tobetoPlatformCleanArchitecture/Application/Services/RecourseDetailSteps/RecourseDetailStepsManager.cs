using Application.Features.RecourseDetailSteps.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseDetailSteps;

public class RecourseDetailStepsManager : IRecourseDetailStepsService
{
    private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
    private readonly RecourseDetailStepBusinessRules _recourseDetailStepBusinessRules;

    public RecourseDetailStepsManager(IRecourseDetailStepRepository recourseDetailStepRepository, RecourseDetailStepBusinessRules recourseDetailStepBusinessRules)
    {
        _recourseDetailStepRepository = recourseDetailStepRepository;
        _recourseDetailStepBusinessRules = recourseDetailStepBusinessRules;
    }

    public async Task<RecourseDetailStep?> GetAsync(
        Expression<Func<RecourseDetailStep, bool>> predicate,
        Func<IQueryable<RecourseDetailStep>, IIncludableQueryable<RecourseDetailStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RecourseDetailStep? recourseDetailStep = await _recourseDetailStepRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return recourseDetailStep;
    }

    public async Task<IPaginate<RecourseDetailStep>?> GetListAsync(
        Expression<Func<RecourseDetailStep, bool>>? predicate = null,
        Func<IQueryable<RecourseDetailStep>, IOrderedQueryable<RecourseDetailStep>>? orderBy = null,
        Func<IQueryable<RecourseDetailStep>, IIncludableQueryable<RecourseDetailStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RecourseDetailStep> recourseDetailStepList = await _recourseDetailStepRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return recourseDetailStepList;
    }

    public async Task<RecourseDetailStep> AddAsync(RecourseDetailStep recourseDetailStep)
    {
        RecourseDetailStep addedRecourseDetailStep = await _recourseDetailStepRepository.AddAsync(recourseDetailStep);

        return addedRecourseDetailStep;
    }

    public async Task<RecourseDetailStep> UpdateAsync(RecourseDetailStep recourseDetailStep)
    {
        RecourseDetailStep updatedRecourseDetailStep = await _recourseDetailStepRepository.UpdateAsync(recourseDetailStep);

        return updatedRecourseDetailStep;
    }

    public async Task<RecourseDetailStep> DeleteAsync(RecourseDetailStep recourseDetailStep, bool permanent = false)
    {
        RecourseDetailStep deletedRecourseDetailStep = await _recourseDetailStepRepository.DeleteAsync(recourseDetailStep);

        return deletedRecourseDetailStep;
    }
}
