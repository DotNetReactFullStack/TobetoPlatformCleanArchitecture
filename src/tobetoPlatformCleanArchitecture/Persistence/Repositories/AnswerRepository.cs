using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnswerRepository : EfRepositoryBase<Answer, int, BaseDbContext>, IAnswerRepository
{
    public AnswerRepository(BaseDbContext context) : base(context)
    {
    }
}