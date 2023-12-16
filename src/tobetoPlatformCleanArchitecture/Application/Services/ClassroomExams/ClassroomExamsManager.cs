using Application.Features.ClassroomExams.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassroomExams;

public class ClassroomExamsManager : IClassroomExamsService
{
    private readonly IClassroomExamRepository _classroomExamRepository;
    private readonly ClassroomExamBusinessRules _classroomExamBusinessRules;

    public ClassroomExamsManager(IClassroomExamRepository classroomExamRepository, ClassroomExamBusinessRules classroomExamBusinessRules)
    {
        _classroomExamRepository = classroomExamRepository;
        _classroomExamBusinessRules = classroomExamBusinessRules;
    }

    public async Task<ClassroomExam?> GetAsync(
        Expression<Func<ClassroomExam, bool>> predicate,
        Func<IQueryable<ClassroomExam>, IIncludableQueryable<ClassroomExam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassroomExam? classroomExam = await _classroomExamRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classroomExam;
    }

    public async Task<IPaginate<ClassroomExam>?> GetListAsync(
        Expression<Func<ClassroomExam, bool>>? predicate = null,
        Func<IQueryable<ClassroomExam>, IOrderedQueryable<ClassroomExam>>? orderBy = null,
        Func<IQueryable<ClassroomExam>, IIncludableQueryable<ClassroomExam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ClassroomExam> classroomExamList = await _classroomExamRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classroomExamList;
    }

    public async Task<ClassroomExam> AddAsync(ClassroomExam classroomExam)
    {
        ClassroomExam addedClassroomExam = await _classroomExamRepository.AddAsync(classroomExam);

        return addedClassroomExam;
    }

    public async Task<ClassroomExam> UpdateAsync(ClassroomExam classroomExam)
    {
        ClassroomExam updatedClassroomExam = await _classroomExamRepository.UpdateAsync(classroomExam);

        return updatedClassroomExam;
    }

    public async Task<ClassroomExam> DeleteAsync(ClassroomExam classroomExam, bool permanent = false)
    {
        ClassroomExam deletedClassroomExam = await _classroomExamRepository.DeleteAsync(classroomExam);

        return deletedClassroomExam;
    }
}
