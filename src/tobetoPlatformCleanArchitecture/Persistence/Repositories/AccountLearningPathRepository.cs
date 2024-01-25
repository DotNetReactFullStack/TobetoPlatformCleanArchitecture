using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountLearningPathRepository : EfRepositoryBase<AccountLearningPath, int, TobetoPlatformDbContext>, IAccountLearningPathRepository
{
    public AccountLearningPathRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}