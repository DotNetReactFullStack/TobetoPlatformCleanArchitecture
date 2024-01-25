using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GraduationStatusRepository : EfRepositoryBase<GraduationStatus, int, TobetoPlatformDbContext>, IGraduationStatusRepository
{
    public GraduationStatusRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}