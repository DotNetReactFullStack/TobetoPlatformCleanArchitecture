using Application.Features.Exams.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Exams.Rules;

public class ExamBusinessRules : BaseBusinessRules
{
    private readonly IExamRepository _examRepository;

    public ExamBusinessRules(IExamRepository examRepository)
    {
        _examRepository = examRepository;
    }

    public Task ExamShouldExistWhenSelected(Exam? exam)
    {
        if (exam == null)
            throw new BusinessException(ExamsBusinessMessages.ExamNotExists);
        return Task.CompletedTask;
    }

    public async Task ExamIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Exam? exam = await _examRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExamShouldExistWhenSelected(exam);
    }
}