using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountLessonRepository : EfRepositoryBase<AccountLesson, int, BaseDbContext>, IAccountLessonRepository
{
    public AccountLessonRepository(BaseDbContext context) : base(context)
    {
    }
}