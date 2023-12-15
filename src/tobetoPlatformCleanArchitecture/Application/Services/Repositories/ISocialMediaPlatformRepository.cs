using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISocialMediaPlatformRepository : IAsyncRepository<SocialMediaPlatform, int>, IRepository<SocialMediaPlatform, int>
{
}