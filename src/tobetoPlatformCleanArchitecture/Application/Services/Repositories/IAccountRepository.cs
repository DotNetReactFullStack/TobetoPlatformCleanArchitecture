using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountRepository : IAsyncRepository<Account, int>, IRepository<Account, int>
{
}