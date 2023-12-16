using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseCategoryRepository : EfRepositoryBase<CourseCategory, int, BaseDbContext>, ICourseCategoryRepository
{
    public CourseCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}