using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RecourseDetailStepRepository : EfRepositoryBase<RecourseDetailStep, int, BaseDbContext>, IRecourseDetailStepRepository
{
    public RecourseDetailStepRepository(BaseDbContext context) : base(context)
    {
    }
}