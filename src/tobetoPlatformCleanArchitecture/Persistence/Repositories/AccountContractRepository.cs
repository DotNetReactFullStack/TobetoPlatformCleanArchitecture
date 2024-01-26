using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountContractRepository : EfRepositoryBase<AccountContract, int, BaseDbContext>, IAccountContractRepository
{
    public AccountContractRepository(BaseDbContext context) : base(context)
    {
    }
}