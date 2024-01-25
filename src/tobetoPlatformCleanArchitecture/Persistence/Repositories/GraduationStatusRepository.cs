using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GraduationStatusRepository : EfRepositoryBase<GraduationStatus, int, BaseDbContext>, IGraduationStatusRepository
{
    public GraduationStatusRepository(BaseDbContext context) : base(context)
    {
    }
}