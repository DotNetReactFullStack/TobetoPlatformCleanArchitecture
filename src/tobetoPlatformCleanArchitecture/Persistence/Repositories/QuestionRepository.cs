using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuestionRepository : EfRepositoryBase<Question, int, TobetoPlatformDbContext>, IQuestionRepository
{
    public QuestionRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}