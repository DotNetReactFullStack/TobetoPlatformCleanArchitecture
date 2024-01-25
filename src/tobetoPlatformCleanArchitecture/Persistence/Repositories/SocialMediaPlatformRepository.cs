using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialMediaPlatformRepository : EfRepositoryBase<SocialMediaPlatform, int, TobetoPlatformDbContext>, ISocialMediaPlatformRepository
{
    public SocialMediaPlatformRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}