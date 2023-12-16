using Application.Features.Courses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Courses.Rules;

public class CourseBusinessRules : BaseBusinessRules
{
    private readonly ICourseRepository _courseRepository;

    public CourseBusinessRules(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public Task CourseShouldExistWhenSelected(Course? course)
    {
        if (course == null)
            throw new BusinessException(CoursesBusinessMessages.CourseNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Course? course = await _courseRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseShouldExistWhenSelected(course);
    }
}