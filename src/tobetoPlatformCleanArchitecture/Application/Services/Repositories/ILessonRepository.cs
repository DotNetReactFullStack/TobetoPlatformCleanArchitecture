using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonRepository : IAsyncRepository<Lesson, int>, IRepository<Lesson, int>
{
}