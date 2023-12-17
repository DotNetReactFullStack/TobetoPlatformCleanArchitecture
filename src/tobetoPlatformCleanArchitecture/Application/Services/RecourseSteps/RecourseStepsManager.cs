using Application.Features.RecourseSteps.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RecourseSteps;

public class RecourseStepsManager : IRecourseStepsService
{
    private readonly IRecourseStepRepository _recourseStepRepository;
    private readonly RecourseStepBusinessRules _recourseStepBusinessRules;

    public RecourseStepsManager(IRecourseStepRepository recourseStepRepository, RecourseStepBusinessRules recourseStepBusinessRules)
    {
        _recourseStepRepository = recourseStepRepository;
        _recourseStepBusinessRules = recourseStepBusinessRules;
    }

    public async Task<RecourseStep?> GetAsync(
        Expression<Func<RecourseStep, bool>> predicate,
        Func<IQueryable<RecourseStep>, IIncludableQueryable<RecourseStep, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RecourseStep? recourseStep = await _recourseStepRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return recourseStep;
    }

    public async Task<IPaginate<RecourseStep>?> GetListAsync(
        Expression<Func<RecourseStep, bool>>? predicate = null,
        Func<IQueryable<RecourseStep>, IOrderedQueryable<RecourseStep>>? orderBy = null,
        Func<IQueryable<RecourseStep>, IIncludableQueryable<RecourseStep, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RecourseStep> recourseStepList = await _recourseStepRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return recourseStepList;
    }

    public async Task<RecourseStep> AddAsync(RecourseStep recourseStep)
    {
        RecourseStep addedRecourseStep = await _recourseStepRepository.AddAsync(recourseStep);

        return addedRecourseStep;
    }

    public async Task<RecourseStep> UpdateAsync(RecourseStep recourseStep)
    {
        RecourseStep updatedRecourseStep = await _recourseStepRepository.UpdateAsync(recourseStep);

        return updatedRecourseStep;
    }

    public async Task<RecourseStep> DeleteAsync(RecourseStep recourseStep, bool permanent = false)
    {
        RecourseStep deletedRecourseStep = await _recourseStepRepository.DeleteAsync(recourseStep);

        return deletedRecourseStep;
    }
}
