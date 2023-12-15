using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAddressRepository : IAsyncRepository<Address, int>, IRepository<Address, int>
{
}