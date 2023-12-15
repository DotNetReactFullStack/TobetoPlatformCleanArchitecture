using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGraduationStatusRepository : IAsyncRepository<GraduationStatus, int>, IRepository<GraduationStatus, int>
{
}