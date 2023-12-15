using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountSocialMediaPlatformRepository : IAsyncRepository<AccountSocialMediaPlatform, int>, IRepository<AccountSocialMediaPlatform, int>
{
}