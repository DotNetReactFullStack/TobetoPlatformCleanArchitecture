using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountClassroomRepository : IAsyncRepository<AccountClassroom, int>, IRepository<AccountClassroom, int>
{
}