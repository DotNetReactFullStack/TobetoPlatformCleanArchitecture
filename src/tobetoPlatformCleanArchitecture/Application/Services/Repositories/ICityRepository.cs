using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICityRepository : IAsyncRepository<City, int>, IRepository<City, int>
{
}