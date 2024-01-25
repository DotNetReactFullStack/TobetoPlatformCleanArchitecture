using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IImageExtensionRepository : IAsyncRepository<ImageExtension, int>, IRepository<ImageExtension, int>
{
}