using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICapabilityRepository : IAsyncRepository<Capability, int>, IRepository<Capability, int>
{
}