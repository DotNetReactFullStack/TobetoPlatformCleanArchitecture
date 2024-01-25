using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementRepository : EfRepositoryBase<Announcement, int, TobetoPlatformDbContext>, IAnnouncementRepository
{
    public AnnouncementRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}