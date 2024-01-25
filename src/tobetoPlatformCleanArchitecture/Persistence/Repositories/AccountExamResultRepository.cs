using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountExamResultRepository : EfRepositoryBase<AccountExamResult, int, TobetoPlatformDbContext>, IAccountExamResultRepository
{
    public AccountExamResultRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}