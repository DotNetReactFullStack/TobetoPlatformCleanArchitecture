using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountLearningPathRepository : IAsyncRepository<AccountLearningPath, int>, IRepository<AccountLearningPath, int>
{
}