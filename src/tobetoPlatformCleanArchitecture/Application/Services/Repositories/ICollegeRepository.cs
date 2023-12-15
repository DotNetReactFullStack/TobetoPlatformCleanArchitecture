using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICollegeRepository : IAsyncRepository<College, int>, IRepository<College, int>
{
}