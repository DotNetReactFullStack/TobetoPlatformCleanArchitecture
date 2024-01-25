using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LearningPathCategoryRepository : EfRepositoryBase<LearningPathCategory, int, TobetoPlatformDbContext>, ILearningPathCategoryRepository
{
    public LearningPathCategoryRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}