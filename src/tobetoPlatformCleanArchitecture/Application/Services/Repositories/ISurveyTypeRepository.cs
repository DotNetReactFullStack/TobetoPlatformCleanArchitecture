using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISurveyTypeRepository : IAsyncRepository<SurveyType, int>, IRepository<SurveyType, int>
{
}