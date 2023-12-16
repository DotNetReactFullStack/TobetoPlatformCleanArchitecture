using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountCourseRepository : EfRepositoryBase<AccountCourse, int, BaseDbContext>, IAccountCourseRepository
{
    public AccountCourseRepository(BaseDbContext context) : base(context)
    {
    }
}