using Application.Features.Classrooms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Classrooms.Rules;

public class ClassroomBusinessRules : BaseBusinessRules
{
    private readonly IClassroomRepository _classroomRepository;

    public ClassroomBusinessRules(IClassroomRepository classroomRepository)
    {
        _classroomRepository = classroomRepository;
    }

    public Task ClassroomShouldExistWhenSelected(Classroom? classroom)
    {
        if (classroom == null)
            throw new BusinessException(ClassroomsBusinessMessages.ClassroomNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassroomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Classroom? classroom = await _classroomRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassroomShouldExistWhenSelected(classroom);
    }
}