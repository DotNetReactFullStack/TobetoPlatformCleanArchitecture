using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountAnnouncementRepository : EfRepositoryBase<AccountAnnouncement, int, TobetoPlatformDbContext>, IAccountAnnouncementRepository
{
    public AccountAnnouncementRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}