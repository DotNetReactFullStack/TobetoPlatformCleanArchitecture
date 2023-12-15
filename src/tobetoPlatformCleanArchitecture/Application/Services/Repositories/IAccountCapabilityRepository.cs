using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountCapabilityRepository : IAsyncRepository<AccountCapability, int>, IRepository<AccountCapability, int>
{
}