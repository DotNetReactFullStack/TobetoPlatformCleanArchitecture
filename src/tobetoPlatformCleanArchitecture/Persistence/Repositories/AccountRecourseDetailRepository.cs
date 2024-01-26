using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountRecourseDetailRepository : EfRepositoryBase<AccountRecourseDetail, int, BaseDbContext>, IAccountRecourseDetailRepository
{
    public AccountRecourseDetailRepository(BaseDbContext context) : base(context)
    {
    }
}