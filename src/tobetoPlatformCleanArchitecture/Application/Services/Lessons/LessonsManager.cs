using Application.Features.Lessons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Lessons;

public class LessonsManager : ILessonsService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly LessonBusinessRules _lessonBusinessRules;

    public LessonsManager(ILessonRepository lessonRepository, LessonBusinessRules lessonBusinessRules)
    {
        _lessonRepository = lessonRepository;
        _lessonBusinessRules = lessonBusinessRules;
    }

    public async Task<Lesson?> GetAsync(
        Expression<Func<Lesson, bool>> predicate,
        Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Lesson? lesson = await _lessonRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lesson;
    }

    public async Task<IPaginate<Lesson>?> GetListAsync(
        Expression<Func<Lesson, bool>>? predicate = null,
        Func<IQueryable<Lesson>, IOrderedQueryable<Lesson>>? orderBy = null,
        Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Lesson> lessonList = await _lessonRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonList;
    }

    public async Task<Lesson> AddAsync(Lesson lesson)
    {
        Lesson addedLesson = await _lessonRepository.AddAsync(lesson);

        return addedLesson;
    }

    public async Task<Lesson> UpdateAsync(Lesson lesson)
    {
        Lesson updatedLesson = await _lessonRepository.UpdateAsync(lesson);

        return updatedLesson;
    }

    public async Task<Lesson> DeleteAsync(Lesson lesson, bool permanent = false)
    {
        Lesson deletedLesson = await _lessonRepository.DeleteAsync(lesson);

        return deletedLesson;
    }
}
