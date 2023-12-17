using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRecourseRepository : IAsyncRepository<Recourse, int>, IRepository<Recourse, int>
{
}