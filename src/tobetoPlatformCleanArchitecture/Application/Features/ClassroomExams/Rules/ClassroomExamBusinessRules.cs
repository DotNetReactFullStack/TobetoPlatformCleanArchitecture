using Application.Features.ClassroomExams.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ClassroomExams.Rules;

public class ClassroomExamBusinessRules : BaseBusinessRules
{
    private readonly IClassroomExamRepository _classroomExamRepository;

    public ClassroomExamBusinessRules(IClassroomExamRepository classroomExamRepository)
    {
        _classroomExamRepository = classroomExamRepository;
    }

    public Task ClassroomExamShouldExistWhenSelected(ClassroomExam? classroomExam)
    {
        if (classroomExam == null)
            throw new BusinessException(ClassroomExamsBusinessMessages.ClassroomExamNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassroomExamIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ClassroomExam? classroomExam = await _classroomExamRepository.GetAsync(
            predicate: ce => ce.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassroomExamShouldExistWhenSelected(classroomExam);
    }
}