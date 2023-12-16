using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassroomRepository : IAsyncRepository<Classroom, int>, IRepository<Classroom, int>
{
}