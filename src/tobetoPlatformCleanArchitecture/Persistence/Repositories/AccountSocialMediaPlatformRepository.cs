using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountSocialMediaPlatformRepository : EfRepositoryBase<AccountSocialMediaPlatform, int, BaseDbContext>, IAccountSocialMediaPlatformRepository
{
    public AccountSocialMediaPlatformRepository(BaseDbContext context) : base(context)
    {
    }
}