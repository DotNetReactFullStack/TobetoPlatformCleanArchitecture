using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassroomExams;

public interface IClassroomExamsService
{
    Task<ClassroomExam?> GetAsync(
        Expression<Func<ClassroomExam, bool>> predicate,
        Func<IQueryable<ClassroomExam>, IIncludableQueryable<ClassroomExam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ClassroomExam>?> GetListAsync(
        Expression<Func<ClassroomExam, bool>>? predicate = null,
        Func<IQueryable<ClassroomExam>, IOrderedQueryable<ClassroomExam>>? orderBy = null,
        Func<IQueryable<ClassroomExam>, IIncludableQueryable<ClassroomExam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ClassroomExam> AddAsync(ClassroomExam classroomExam);
    Task<ClassroomExam> UpdateAsync(ClassroomExam classroomExam);
    Task<ClassroomExam> DeleteAsync(ClassroomExam classroomExam, bool permanent = false);
}
