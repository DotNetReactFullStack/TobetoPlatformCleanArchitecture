using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExperienceRepository : IAsyncRepository<Experience, int>, IRepository<Experience, int>
{
}