using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountRecourseDetailRepository : EfRepositoryBase<AccountRecourseDetail, int, TobetoPlatformDbContext>, IAccountRecourseDetailRepository
{
    public AccountRecourseDetailRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}