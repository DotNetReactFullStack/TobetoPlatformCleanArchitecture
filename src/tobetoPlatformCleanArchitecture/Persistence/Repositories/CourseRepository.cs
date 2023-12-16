using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseRepository : EfRepositoryBase<Course, int, BaseDbContext>, ICourseRepository
{
    public CourseRepository(BaseDbContext context) : base(context)
    {
    }
}