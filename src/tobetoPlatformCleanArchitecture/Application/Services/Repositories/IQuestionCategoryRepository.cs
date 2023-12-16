using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IQuestionCategoryRepository : IAsyncRepository<QuestionCategory, int>, IRepository<QuestionCategory, int>
{
}