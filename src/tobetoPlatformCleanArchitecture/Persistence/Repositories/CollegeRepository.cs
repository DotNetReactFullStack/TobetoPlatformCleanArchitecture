using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CollegeRepository : EfRepositoryBase<College, int, BaseDbContext>, ICollegeRepository
{
    public CollegeRepository(BaseDbContext context) : base(context)
    {
    }
}