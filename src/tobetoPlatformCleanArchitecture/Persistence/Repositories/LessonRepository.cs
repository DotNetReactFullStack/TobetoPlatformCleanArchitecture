using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonRepository : EfRepositoryBase<Lesson, int, BaseDbContext>, ILessonRepository
{
    public LessonRepository(BaseDbContext context) : base(context)
    {
    }
}