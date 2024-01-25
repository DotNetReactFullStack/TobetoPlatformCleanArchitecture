using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassroomRepository : EfRepositoryBase<Classroom, int, TobetoPlatformDbContext>, IClassroomRepository
{
    public ClassroomRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}