using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCourseRepository : EfRepositoryBase<AccountCourse, int, TobetoPlatformDbContext>, IAccountCourseRepository
{
    public AccountCourseRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}