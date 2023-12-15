using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialMediaPlatformRepository : EfRepositoryBase<SocialMediaPlatform, int, BaseDbContext>, ISocialMediaPlatformRepository
{
    public SocialMediaPlatformRepository(BaseDbContext context) : base(context)
    {
    }
}