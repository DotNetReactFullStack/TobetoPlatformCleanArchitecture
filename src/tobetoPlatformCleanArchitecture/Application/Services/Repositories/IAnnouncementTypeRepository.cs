using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAnnouncementTypeRepository : IAsyncRepository<AnnouncementType, int>, IRepository<AnnouncementType, int>
{
}