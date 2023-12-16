using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseLearningPathRepository : IAsyncRepository<CourseLearningPath, int>, IRepository<CourseLearningPath, int>
{
}