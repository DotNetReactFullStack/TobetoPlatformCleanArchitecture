using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRecourseDetailRepository : IAsyncRepository<RecourseDetail, int>, IRepository<RecourseDetail, int>
{
}