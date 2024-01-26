using Application.Features.RecourseDetailSteps.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RecourseDetailSteps.Rules;

public class RecourseDetailStepBusinessRules : BaseBusinessRules
{
    private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;

    public RecourseDetailStepBusinessRules(IRecourseDetailStepRepository recourseDetailStepRepository)
    {
        _recourseDetailStepRepository = recourseDetailStepRepository;
    }

    public Task RecourseDetailStepShouldExistWhenSelected(RecourseDetailStep? recourseDetailStep)
    {
        if (recourseDetailStep == null)
            throw new BusinessException(RecourseDetailStepsBusinessMessages.RecourseDetailStepNotExists);
        return Task.CompletedTask;
    }

    public async Task RecourseDetailStepIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RecourseDetailStep? recourseDetailStep = await _recourseDetailStepRepository.GetAsync(
            predicate: rds => rds.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RecourseDetailStepShouldExistWhenSelected(recourseDetailStep);
    }
}