using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, int, BaseDbContext>, ICityRepository
{
    public CityRepository(BaseDbContext context) : base(context)
    {
    }
}