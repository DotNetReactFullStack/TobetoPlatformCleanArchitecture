using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountRecourseRepository : EfRepositoryBase<AccountRecourse, int, BaseDbContext>, IAccountRecourseRepository
{
    public AccountRecourseRepository(BaseDbContext context) : base(context)
    {
    }
}