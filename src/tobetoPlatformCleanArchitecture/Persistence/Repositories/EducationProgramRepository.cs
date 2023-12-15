using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationProgramRepository : EfRepositoryBase<EducationProgram, int, BaseDbContext>, IEducationProgramRepository
{
    public EducationProgramRepository(BaseDbContext context) : base(context)
    {
    }
}