using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SurveyRepository : EfRepositoryBase<Survey, int, TobetoPlatformDbContext>, ISurveyRepository
{
    public SurveyRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}