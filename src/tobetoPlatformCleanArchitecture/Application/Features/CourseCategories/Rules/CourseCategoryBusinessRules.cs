using Application.Features.CourseCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CourseCategories.Rules;

public class CourseCategoryBusinessRules : BaseBusinessRules
{
    private readonly ICourseCategoryRepository _courseCategoryRepository;

    public CourseCategoryBusinessRules(ICourseCategoryRepository courseCategoryRepository)
    {
        _courseCategoryRepository = courseCategoryRepository;
    }

    public Task CourseCategoryShouldExistWhenSelected(CourseCategory? courseCategory)
    {
        if (courseCategory == null)
            throw new BusinessException(CourseCategoriesBusinessMessages.CourseCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task CourseCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CourseCategoryShouldExistWhenSelected(courseCategory);
    }
}