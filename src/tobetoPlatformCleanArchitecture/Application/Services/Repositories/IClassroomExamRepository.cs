using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassroomExamRepository : IAsyncRepository<ClassroomExam, int>, IRepository<ClassroomExam, int>
{
}