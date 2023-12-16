using Application.Features.Answers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Answers;

public class AnswersManager : IAnswersService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly AnswerBusinessRules _answerBusinessRules;

    public AnswersManager(IAnswerRepository answerRepository, AnswerBusinessRules answerBusinessRules)
    {
        _answerRepository = answerRepository;
        _answerBusinessRules = answerBusinessRules;
    }

    public async Task<Answer?> GetAsync(
        Expression<Func<Answer, bool>> predicate,
        Func<IQueryable<Answer>, IIncludableQueryable<Answer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Answer? answer = await _answerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return answer;
    }

    public async Task<IPaginate<Answer>?> GetListAsync(
        Expression<Func<Answer, bool>>? predicate = null,
        Func<IQueryable<Answer>, IOrderedQueryable<Answer>>? orderBy = null,
        Func<IQueryable<Answer>, IIncludableQueryable<Answer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Answer> answerList = await _answerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return answerList;
    }

    public async Task<Answer> AddAsync(Answer answer)
    {
        Answer addedAnswer = await _answerRepository.AddAsync(answer);

        return addedAnswer;
    }

    public async Task<Answer> UpdateAsync(Answer answer)
    {
        Answer updatedAnswer = await _answerRepository.UpdateAsync(answer);

        return updatedAnswer;
    }

    public async Task<Answer> DeleteAsync(Answer answer, bool permanent = false)
    {
        Answer deletedAnswer = await _answerRepository.DeleteAsync(answer);

        return deletedAnswer;
    }
}
