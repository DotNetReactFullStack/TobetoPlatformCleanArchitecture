using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseRepository : EfRepositoryBase<Course, int, TobetoPlatformDbContext>, ICourseRepository
{
    public CourseRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}