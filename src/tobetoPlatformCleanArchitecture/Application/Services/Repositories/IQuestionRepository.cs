using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IQuestionRepository : IAsyncRepository<Question, int>, IRepository<Question, int>
{
}