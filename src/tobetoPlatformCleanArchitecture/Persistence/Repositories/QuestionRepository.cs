using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionRepository : EfRepositoryBase<Question, int, BaseDbContext>, IQuestionRepository
{
    public QuestionRepository(BaseDbContext context) : base(context)
    {
    }
}