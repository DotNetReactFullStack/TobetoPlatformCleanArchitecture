using Application.Features.Questions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Questions.Rules;

public class QuestionBusinessRules : BaseBusinessRules
{
    private readonly IQuestionRepository _questionRepository;

    public QuestionBusinessRules(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public Task QuestionShouldExistWhenSelected(Question? question)
    {
        if (question == null)
            throw new BusinessException(QuestionsBusinessMessages.QuestionNotExists);
        return Task.CompletedTask;
    }

    public async Task QuestionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Question? question = await _questionRepository.GetAsync(
            predicate: q => q.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await QuestionShouldExistWhenSelected(question);
    }
}