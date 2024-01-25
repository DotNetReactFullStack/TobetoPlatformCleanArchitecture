using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseCategoryRepository : EfRepositoryBase<CourseCategory, int, TobetoPlatformDbContext>, ICourseCategoryRepository
{
    public CourseCategoryRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}