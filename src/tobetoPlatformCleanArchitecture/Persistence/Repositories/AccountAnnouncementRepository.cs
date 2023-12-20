using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountAnnouncementRepository : EfRepositoryBase<AccountAnnouncement, int, BaseDbContext>, IAccountAnnouncementRepository
{
    public AccountAnnouncementRepository(BaseDbContext context) : base(context)
    {
    }
}