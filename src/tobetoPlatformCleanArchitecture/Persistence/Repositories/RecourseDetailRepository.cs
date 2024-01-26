using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RecourseDetailRepository : EfRepositoryBase<RecourseDetail, int, BaseDbContext>, IRecourseDetailRepository
{
    public RecourseDetailRepository(BaseDbContext context) : base(context)
    {
    }
}