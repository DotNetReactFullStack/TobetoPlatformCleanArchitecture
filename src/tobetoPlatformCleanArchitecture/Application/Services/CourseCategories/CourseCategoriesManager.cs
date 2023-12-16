using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CourseCategories;

public class CourseCategoriesManager : ICourseCategoriesService
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;
    private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

    public CourseCategoriesManager(ICourseCategoryRepository courseCategoryRepository, CourseCategoryBusinessRules courseCategoryBusinessRules)
    {
        _courseCategoryRepository = courseCategoryRepository;
        _courseCategoryBusinessRules = courseCategoryBusinessRules;
    }

    public async Task<CourseCategory?> GetAsync(
        Expression<Func<CourseCategory, bool>> predicate,
        Func<IQueryable<CourseCategory>, IIncludableQueryable<CourseCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return courseCategory;
    }

    public async Task<IPaginate<CourseCategory>?> GetListAsync(
        Expression<Func<CourseCategory, bool>>? predicate = null,
        Func<IQueryable<CourseCategory>, IOrderedQueryable<CourseCategory>>? orderBy = null,
        Func<IQueryable<CourseCategory>, IIncludableQueryable<CourseCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CourseCategory> courseCategoryList = await _courseCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return courseCategoryList;
    }

    public async Task<CourseCategory> AddAsync(CourseCategory courseCategory)
    {
        CourseCategory addedCourseCategory = await _courseCategoryRepository.AddAsync(courseCategory);

        return addedCourseCategory;
    }

    public async Task<CourseCategory> UpdateAsync(CourseCategory courseCategory)
    {
        CourseCategory updatedCourseCategory = await _courseCategoryRepository.UpdateAsync(courseCategory);

        return updatedCourseCategory;
    }

    public async Task<CourseCategory> DeleteAsync(CourseCategory courseCategory, bool permanent = false)
    {
        CourseCategory deletedCourseCategory = await _courseCategoryRepository.DeleteAsync(courseCategory);

        return deletedCourseCategory;
    }
}
