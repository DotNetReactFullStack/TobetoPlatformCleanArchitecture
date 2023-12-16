using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountExamResultRepository : EfRepositoryBase<AccountExamResult, int, BaseDbContext>, IAccountExamResultRepository
{
    public AccountExamResultRepository(BaseDbContext context) : base(context)
    {
    }
}