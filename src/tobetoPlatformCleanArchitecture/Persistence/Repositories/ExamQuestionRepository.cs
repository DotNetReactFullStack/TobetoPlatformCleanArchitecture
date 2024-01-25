using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ExamQuestionRepository : EfRepositoryBase<ExamQuestion, int, TobetoPlatformDbContext>, IExamQuestionRepository
{
    public ExamQuestionRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}