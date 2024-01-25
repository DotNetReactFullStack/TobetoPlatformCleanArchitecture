using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationProgramRepository : EfRepositoryBase<EducationProgram, int, TobetoPlatformDbContext>, IEducationProgramRepository
{
    public EducationProgramRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}