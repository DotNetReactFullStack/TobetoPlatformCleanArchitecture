using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyTypeRepository : EfRepositoryBase<SurveyType, int, BaseDbContext>, ISurveyTypeRepository
{
    public SurveyTypeRepository(BaseDbContext context) : base(context)
    {
    }
}