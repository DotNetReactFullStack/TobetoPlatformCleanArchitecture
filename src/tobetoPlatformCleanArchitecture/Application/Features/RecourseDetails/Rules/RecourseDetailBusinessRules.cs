using Application.Features.RecourseDetails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.RecourseDetails.Rules;

public class RecourseDetailBusinessRules : BaseBusinessRules
{
    private readonly IRecourseDetailRepository _recourseDetailRepository;

    public RecourseDetailBusinessRules(IRecourseDetailRepository recourseDetailRepository)
    {
        _recourseDetailRepository = recourseDetailRepository;
    }

    public Task RecourseDetailShouldExistWhenSelected(RecourseDetail? recourseDetail)
    {
        if (recourseDetail == null)
            throw new BusinessException(RecourseDetailsBusinessMessages.RecourseDetailNotExists);
        return Task.CompletedTask;
    }

    public async Task RecourseDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RecourseDetail? recourseDetail = await _recourseDetailRepository.GetAsync(
            predicate: rd => rd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RecourseDetailShouldExistWhenSelected(recourseDetail);
    }
}