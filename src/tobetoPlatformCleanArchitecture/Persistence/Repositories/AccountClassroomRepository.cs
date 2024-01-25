using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountClassroomRepository : EfRepositoryBase<AccountClassroom, int, TobetoPlatformDbContext>, IAccountClassroomRepository
{
    public AccountClassroomRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}