using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountRecourseDetailRepository : IAsyncRepository<AccountRecourseDetail, int>, IRepository<AccountRecourseDetail, int>
{
}