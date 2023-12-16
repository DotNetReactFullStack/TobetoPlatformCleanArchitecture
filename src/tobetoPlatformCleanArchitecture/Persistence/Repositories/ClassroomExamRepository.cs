using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassroomExamRepository : EfRepositoryBase<ClassroomExam, int, BaseDbContext>, IClassroomExamRepository
{
    public ClassroomExamRepository(BaseDbContext context) : base(context)
    {
    }
}