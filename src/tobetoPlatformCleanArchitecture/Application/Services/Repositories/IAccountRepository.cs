using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountRepository : IAsyncRepository<Account, Guid>, IRepository<Account, Guid>
{
}