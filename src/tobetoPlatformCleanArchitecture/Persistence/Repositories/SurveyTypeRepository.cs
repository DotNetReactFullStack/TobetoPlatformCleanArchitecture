using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyTypeRepository : EfRepositoryBase<SurveyType, int, TobetoPlatformDbContext>, ISurveyTypeRepository
{
    public SurveyTypeRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}