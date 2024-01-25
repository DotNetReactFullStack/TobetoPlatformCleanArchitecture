using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementTypeRepository : EfRepositoryBase<AnnouncementType, int, TobetoPlatformDbContext>, IAnnouncementTypeRepository
{
    public AnnouncementTypeRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}