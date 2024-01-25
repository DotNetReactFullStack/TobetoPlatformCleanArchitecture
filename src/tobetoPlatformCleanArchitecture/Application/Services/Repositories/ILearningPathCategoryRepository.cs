using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILearningPathCategoryRepository : IAsyncRepository<LearningPathCategory, int>, IRepository<LearningPathCategory, int>
{
}