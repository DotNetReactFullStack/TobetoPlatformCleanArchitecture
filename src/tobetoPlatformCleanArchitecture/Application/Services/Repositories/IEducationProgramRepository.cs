using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEducationProgramRepository : IAsyncRepository<EducationProgram, int>, IRepository<EducationProgram, int>
{
}