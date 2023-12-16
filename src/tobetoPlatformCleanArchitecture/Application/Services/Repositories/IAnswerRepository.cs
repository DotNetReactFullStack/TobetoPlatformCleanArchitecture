using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAnswerRepository : IAsyncRepository<Answer, int>, IRepository<Answer, int>
{
}