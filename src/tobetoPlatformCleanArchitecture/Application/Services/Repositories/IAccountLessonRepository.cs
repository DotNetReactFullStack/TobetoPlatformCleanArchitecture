using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountLessonRepository : IAsyncRepository<AccountLesson, int>, IRepository<AccountLesson, int>
{
}