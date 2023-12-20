using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountAnnouncementRepository : IAsyncRepository<AccountAnnouncement, int>, IRepository<AccountAnnouncement, int>
{
}