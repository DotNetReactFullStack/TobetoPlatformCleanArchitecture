using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Courses;

public class CoursesManager : ICoursesService
{
    private readonly ICourseRepository _courseRepository;
    private readonly CourseBusinessRules _courseBusinessRules;

    public CoursesManager(ICourseRepository courseRepository, CourseBusinessRules courseBusinessRules)
    {
        _courseRepository = courseRepository;
        _courseBusinessRules = courseBusinessRules;
    }

    public async Task<Course?> GetAsync(
        Expression<Func<Course, bool>> predicate,
        Func<IQueryable<Course>, IIncludableQueryable<Course, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Course? course = await _courseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return course;
    }

    public async Task<IPaginate<Course>?> GetListAsync(
        Expression<Func<Course, bool>>? predicate = null,
        Func<IQueryable<Course>, IOrderedQueryable<Course>>? orderBy = null,
        Func<IQueryable<Course>, IIncludableQueryable<Course, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Course> courseList = await _courseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseList;
    }

    public async Task<Course> AddAsync(Course course)
    {
        Course addedCourse = await _courseRepository.AddAsync(course);

        return addedCourse;
    }

    public async Task<Course> UpdateAsync(Course course)
    {
        Course updatedCourse = await _courseRepository.UpdateAsync(course);

        return updatedCourse;
    }

    public async Task<Course> DeleteAsync(Course course, bool permanent = false)
    {
        Course deletedCourse = await _courseRepository.DeleteAsync(course);

        return deletedCourse;
    }
}
