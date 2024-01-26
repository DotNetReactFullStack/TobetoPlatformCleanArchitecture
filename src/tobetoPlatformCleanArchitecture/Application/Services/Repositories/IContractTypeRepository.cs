using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IContractTypeRepository : IAsyncRepository<ContractType, int>, IRepository<ContractType, int>
{
}