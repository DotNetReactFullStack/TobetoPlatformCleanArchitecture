using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCapabilityRepository : EfRepositoryBase<AccountCapability, int, TobetoPlatformDbContext>, IAccountCapabilityRepository
{
    public AccountCapabilityRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}