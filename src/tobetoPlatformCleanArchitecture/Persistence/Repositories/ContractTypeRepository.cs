using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContractTypeRepository : EfRepositoryBase<ContractType, int, BaseDbContext>, IContractTypeRepository
{
    public ContractTypeRepository(BaseDbContext context) : base(context)
    {
    }
}