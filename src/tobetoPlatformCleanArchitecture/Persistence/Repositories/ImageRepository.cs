using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ImageRepository : EfRepositoryBase<Image, int, BaseDbContext>, IImageRepository
{
    public ImageRepository(BaseDbContext context) : base(context)
    {
    }
}