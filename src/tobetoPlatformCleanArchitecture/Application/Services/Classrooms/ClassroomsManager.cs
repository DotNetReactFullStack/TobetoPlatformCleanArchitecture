using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Classrooms;

public class ClassroomsManager : IClassroomsService
{
    private readonly IClassroomRepository _classroomRepository;
    private readonly ClassroomBusinessRules _classroomBusinessRules;

    public ClassroomsManager(IClassroomRepository classroomRepository, ClassroomBusinessRules classroomBusinessRules)
    {
        _classroomRepository = classroomRepository;
        _classroomBusinessRules = classroomBusinessRules;
    }

    public async Task<Classroom?> GetAsync(
        Expression<Func<Classroom, bool>> predicate,
        Func<IQueryable<Classroom>, IIncludableQueryable<Classroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Classroom? classroom = await _classroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classroom;
    }

    public async Task<IPaginate<Classroom>?> GetListAsync(
        Expression<Func<Classroom, bool>>? predicate = null,
        Func<IQueryable<Classroom>, IOrderedQueryable<Classroom>>? orderBy = null,
        Func<IQueryable<Classroom>, IIncludableQueryable<Classroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Classroom> classroomList = await _classroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classroomList;
    }

    public async Task<Classroom> AddAsync(Classroom classroom)
    {
        Classroom addedClassroom = await _classroomRepository.AddAsync(classroom);

        return addedClassroom;
    }

    public async Task<Classroom> UpdateAsync(Classroom classroom)
    {
        Classroom updatedClassroom = await _classroomRepository.UpdateAsync(classroom);

        return updatedClassroom;
    }

    public async Task<Classroom> DeleteAsync(Classroom classroom, bool permanent = false)
    {
        Classroom deletedClassroom = await _classroomRepository.DeleteAsync(classroom);

        return deletedClassroom;
    }
}
