using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IImageRepository : IAsyncRepository<Image, int>, IRepository<Image, int>
{
}