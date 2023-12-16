using Application.Features.Lessons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Lessons.Rules;

public class LessonBusinessRules : BaseBusinessRules
{
    private readonly ILessonRepository _lessonRepository;

    public LessonBusinessRules(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public Task LessonShouldExistWhenSelected(Lesson? lesson)
    {
        if (lesson == null)
            throw new BusinessException(LessonsBusinessMessages.LessonNotExists);
        return Task.CompletedTask;
    }

    public async Task LessonIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Lesson? lesson = await _lessonRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LessonShouldExistWhenSelected(lesson);
    }
}