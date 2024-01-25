using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonRepository : EfRepositoryBase<Lesson, int, TobetoPlatformDbContext>, ILessonRepository
{
    public LessonRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}