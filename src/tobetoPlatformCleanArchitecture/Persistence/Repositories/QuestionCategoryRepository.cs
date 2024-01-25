using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionCategoryRepository : EfRepositoryBase<QuestionCategory, int, TobetoPlatformDbContext>, IQuestionCategoryRepository
{
    public QuestionCategoryRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}