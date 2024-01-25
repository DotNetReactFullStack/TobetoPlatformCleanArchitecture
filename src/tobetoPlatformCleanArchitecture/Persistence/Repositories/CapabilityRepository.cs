using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CapabilityRepository : EfRepositoryBase<Capability, int, TobetoPlatformDbContext>, ICapabilityRepository
{
    public CapabilityRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}