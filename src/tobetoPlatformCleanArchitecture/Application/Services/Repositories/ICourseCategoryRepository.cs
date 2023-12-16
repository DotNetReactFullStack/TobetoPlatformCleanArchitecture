using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseCategoryRepository : IAsyncRepository<CourseCategory, int>, IRepository<CourseCategory, int>
{
}