using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountLearningPathRepository : EfRepositoryBase<AccountLearningPath, int, BaseDbContext>, IAccountLearningPathRepository
{
    public AccountLearningPathRepository(BaseDbContext context) : base(context)
    {
    }
}