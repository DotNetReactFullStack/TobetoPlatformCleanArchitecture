using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementTypeRepository : EfRepositoryBase<AnnouncementType, int, BaseDbContext>, IAnnouncementTypeRepository
{
    public AnnouncementTypeRepository(BaseDbContext context) : base(context)
    {
    }
}