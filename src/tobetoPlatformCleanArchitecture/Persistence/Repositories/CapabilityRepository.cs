using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CapabilityRepository : EfRepositoryBase<Capability, int, BaseDbContext>, ICapabilityRepository
{
    public CapabilityRepository(BaseDbContext context) : base(context)
    {
    }
}