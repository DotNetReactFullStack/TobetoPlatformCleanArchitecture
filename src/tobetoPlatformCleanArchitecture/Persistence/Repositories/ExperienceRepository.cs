using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExperienceRepository : EfRepositoryBase<Experience, int, TobetoPlatformDbContext>, IExperienceRepository
{
    public ExperienceRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}