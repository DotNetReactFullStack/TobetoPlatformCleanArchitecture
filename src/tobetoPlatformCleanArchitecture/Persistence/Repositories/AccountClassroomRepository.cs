using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountClassroomRepository : EfRepositoryBase<AccountClassroom, int, BaseDbContext>, IAccountClassroomRepository
{
    public AccountClassroomRepository(BaseDbContext context) : base(context)
    {
    }
}