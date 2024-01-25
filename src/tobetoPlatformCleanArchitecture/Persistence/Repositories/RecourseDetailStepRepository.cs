using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RecourseDetailStepRepository : EfRepositoryBase<RecourseDetailStep, int, TobetoPlatformDbContext>, IRecourseDetailStepRepository
{
    public RecourseDetailStepRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}