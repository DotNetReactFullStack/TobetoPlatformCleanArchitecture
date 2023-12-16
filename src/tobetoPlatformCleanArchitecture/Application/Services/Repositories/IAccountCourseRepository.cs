using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountCourseRepository : IAsyncRepository<AccountCourse, int>, IRepository<AccountCourse, int>
{
}