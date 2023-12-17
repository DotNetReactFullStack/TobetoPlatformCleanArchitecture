using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRecourseStepRepository : IAsyncRepository<RecourseStep, int>, IRepository<RecourseStep, int>
{
}