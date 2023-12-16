using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyRepository : EfRepositoryBase<Survey, int, BaseDbContext>, ISurveyRepository
{
    public SurveyRepository(BaseDbContext context) : base(context)
    {
    }
}