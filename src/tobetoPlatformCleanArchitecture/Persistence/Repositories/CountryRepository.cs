using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CountryRepository : EfRepositoryBase<Country, int, TobetoPlatformDbContext>, ICountryRepository
{
    public CountryRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}