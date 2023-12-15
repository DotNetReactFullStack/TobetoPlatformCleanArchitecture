using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AddressRepository : EfRepositoryBase<Address, int, BaseDbContext>, IAddressRepository
{
    public AddressRepository(BaseDbContext context) : base(context)
    {
    }
}