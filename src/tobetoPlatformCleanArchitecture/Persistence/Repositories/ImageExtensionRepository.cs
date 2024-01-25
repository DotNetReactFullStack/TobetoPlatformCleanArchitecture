using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ImageExtensionRepository : EfRepositoryBase<ImageExtension, int, TobetoPlatformDbContext>, IImageExtensionRepository
{
    public ImageExtensionRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}