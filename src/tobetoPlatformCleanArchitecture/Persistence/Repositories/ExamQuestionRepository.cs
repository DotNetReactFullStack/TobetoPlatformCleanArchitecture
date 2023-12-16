using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExamQuestionRepository : EfRepositoryBase<ExamQuestion, int, BaseDbContext>, IExamQuestionRepository
{
    public ExamQuestionRepository(BaseDbContext context) : base(context)
    {
    }
}