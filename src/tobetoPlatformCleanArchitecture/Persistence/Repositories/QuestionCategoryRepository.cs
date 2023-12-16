using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionCategoryRepository : EfRepositoryBase<QuestionCategory, int, BaseDbContext>, IQuestionCategoryRepository
{
    public QuestionCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}