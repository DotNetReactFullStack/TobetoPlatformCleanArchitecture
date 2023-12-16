using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAnnouncementRepository : IAsyncRepository<Announcement, int>, IRepository<Announcement, int>
{
}