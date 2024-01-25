using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AddressRepository : EfRepositoryBase<Address, int, TobetoPlatformDbContext>, IAddressRepository
{
    public AddressRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}