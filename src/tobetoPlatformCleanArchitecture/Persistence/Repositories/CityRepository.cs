using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, int, TobetoPlatformDbContext>, ICityRepository
{
    public CityRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}