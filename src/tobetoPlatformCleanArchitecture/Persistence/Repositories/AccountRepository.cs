using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountRepository : EfRepositoryBase<Account, int, TobetoPlatformDbContext>, IAccountRepository
{
    public AccountRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}