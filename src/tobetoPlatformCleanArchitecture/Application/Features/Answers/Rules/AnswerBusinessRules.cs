using Application.Features.Answers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Answers.Rules;

public class AnswerBusinessRules : BaseBusinessRules
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerBusinessRules(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public Task AnswerShouldExistWhenSelected(Answer? answer)
    {
        if (answer == null)
            throw new BusinessException(AnswersBusinessMessages.AnswerNotExists);
        return Task.CompletedTask;
    }

    public async Task AnswerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Answer? answer = await _answerRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AnswerShouldExistWhenSelected(answer);
    }
}