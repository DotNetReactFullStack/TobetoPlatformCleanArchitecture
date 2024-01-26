using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRecourseDetailStepRepository : IAsyncRepository<RecourseDetailStep, int>, IRepository<RecourseDetailStep, int>
{
}