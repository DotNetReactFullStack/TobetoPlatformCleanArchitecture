using Application.Features.RecourseSteps.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RecourseSteps.Rules;

public class RecourseStepBusinessRules : BaseBusinessRules
{
    private readonly IRecourseStepRepository _recourseStepRepository;

    public RecourseStepBusinessRules(IRecourseStepRepository recourseStepRepository)
    {
        _recourseStepRepository = recourseStepRepository;
    }

    public Task RecourseStepShouldExistWhenSelected(RecourseStep? recourseStep)
    {
        if (recourseStep == null)
            throw new BusinessException(RecourseStepsBusinessMessages.RecourseStepNotExists);
        return Task.CompletedTask;
    }

    public async Task RecourseStepIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RecourseStep? recourseStep = await _recourseStepRepository.GetAsync(
            predicate: rs => rs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RecourseStepShouldExistWhenSelected(recourseStep);
    }
}