using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAccountExamResultRepository : IAsyncRepository<AccountExamResult, int>, IRepository<AccountExamResult, int>
{
}