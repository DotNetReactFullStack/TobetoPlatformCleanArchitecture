using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RecourseStepRepository : EfRepositoryBase<RecourseStep, int, BaseDbContext>, IRecourseStepRepository
{
    public RecourseStepRepository(BaseDbContext context) : base(context)
    {
    }
}