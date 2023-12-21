using Application.Features.AccountSocialMediaPlatforms.Constants;
using Application.Features.ExamQuestions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ExamQuestions.Rules;

public class ExamQuestionBusinessRules : BaseBusinessRules
{
    private readonly IExamQuestionRepository _examQuestionRepository;

    public ExamQuestionBusinessRules(IExamQuestionRepository examQuestionRepository)
    {
        _examQuestionRepository = examQuestionRepository;
    }

    public Task ExamQuestionShouldExistWhenSelected(ExamQuestion? examQuestion)
    {
        if (examQuestion == null)
            throw new BusinessException(ExamQuestionsBusinessMessages.ExamQuestionNotExists);
        return Task.CompletedTask;
    }

    public async Task ExamQuestionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ExamQuestion? examQuestion = await _examQuestionRepository.GetAsync(
            predicate: eq => eq.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ExamQuestionShouldExistWhenSelected(examQuestion);
    }

    public Task ExamCanHasMaximumOneHundredQuestions(ExamQuestion examQuestion)
    {
        var examQuestionCount = _examQuestionRepository.GetList(e => e.ExamId == examQuestion.ExamId).Count;

        if (examQuestionCount >= 100)
            throw new BusinessException(ExamQuestionsBusinessMessages.ExamCanHasMaximumOneHundredQuestions);
        return Task.CompletedTask;
    }
}