using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExamQuestionRepository : IAsyncRepository<ExamQuestion, int>, IRepository<ExamQuestion, int>
{
}