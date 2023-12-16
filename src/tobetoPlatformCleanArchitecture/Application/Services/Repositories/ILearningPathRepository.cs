using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILearningPathRepository : IAsyncRepository<LearningPath, int>, IRepository<LearningPath, int>
{
}