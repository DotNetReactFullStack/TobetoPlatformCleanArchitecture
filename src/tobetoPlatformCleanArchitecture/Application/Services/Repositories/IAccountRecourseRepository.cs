using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountRecourseRepository : IAsyncRepository<AccountRecourse, int>, IRepository<AccountRecourse, int>
{
}