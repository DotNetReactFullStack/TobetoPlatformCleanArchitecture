using Application.Features.Recourses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Recourses.Rules;

public class RecourseBusinessRules : BaseBusinessRules
{
    private readonly IRecourseRepository _recourseRepository;

    public RecourseBusinessRules(IRecourseRepository recourseRepository)
    {
        _recourseRepository = recourseRepository;
    }

    public Task RecourseShouldExistWhenSelected(Recourse? recourse)
    {
        if (recourse == null)
            throw new BusinessException(RecoursesBusinessMessages.RecourseNotExists);
        return Task.CompletedTask;
    }

    public async Task RecourseIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Recourse? recourse = await _recourseRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RecourseShouldExistWhenSelected(recourse);
    }
}