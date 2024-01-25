using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseLearningPathRepository : EfRepositoryBase<CourseLearningPath, int, TobetoPlatformDbContext>, ICourseLearningPathRepository
{
    public CourseLearningPathRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}