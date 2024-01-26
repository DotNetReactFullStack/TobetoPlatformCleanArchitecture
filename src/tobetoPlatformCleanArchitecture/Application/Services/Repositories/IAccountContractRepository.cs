using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountContractRepository : IAsyncRepository<AccountContract, int>, IRepository<AccountContract, int>
{
}