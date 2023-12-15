using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DistrictRepository : EfRepositoryBase<District, int, BaseDbContext>, IDistrictRepository
{
    public DistrictRepository(BaseDbContext context) : base(context)
    {
    }
}