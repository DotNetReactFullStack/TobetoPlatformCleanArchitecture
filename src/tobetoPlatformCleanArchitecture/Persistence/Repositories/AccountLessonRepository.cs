using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AccountLessonRepository : EfRepositoryBase<AccountLesson, int, TobetoPlatformDbContext>, IAccountLessonRepository
{
    public AccountLessonRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}