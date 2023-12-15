using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDistrictRepository : IAsyncRepository<District, int>, IRepository<District, int>
{
}