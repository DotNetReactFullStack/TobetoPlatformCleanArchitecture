using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContractRepository : EfRepositoryBase<Contract, int, BaseDbContext>, IContractRepository
{
    public ContractRepository(BaseDbContext context) : base(context)
    {
    }
}