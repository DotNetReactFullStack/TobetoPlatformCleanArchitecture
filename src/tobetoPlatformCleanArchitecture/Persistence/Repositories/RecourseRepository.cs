using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RecourseRepository : EfRepositoryBase<Recourse, int, TobetoPlatformDbContext>, IRecourseRepository
{
    public RecourseRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}