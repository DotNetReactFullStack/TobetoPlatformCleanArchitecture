using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IContractRepository : IAsyncRepository<Contract, int>, IRepository<Contract, int>
{
}