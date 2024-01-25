using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountSocialMediaPlatformRepository : EfRepositoryBase<AccountSocialMediaPlatform, int, TobetoPlatformDbContext>, IAccountSocialMediaPlatformRepository
{
    public AccountSocialMediaPlatformRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}