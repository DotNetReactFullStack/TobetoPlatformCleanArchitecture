using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassroomExamRepository : EfRepositoryBase<ClassroomExam, int, TobetoPlatformDbContext>, IClassroomExamRepository
{
    public ClassroomExamRepository(TobetoPlatformDbContext context) : base(context)
    {
    }
}