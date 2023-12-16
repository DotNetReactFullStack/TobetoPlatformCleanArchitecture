using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Questions;

public class QuestionsManager : IQuestionsService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly QuestionBusinessRules _questionBusinessRules;

    public QuestionsManager(IQuestionRepository questionRepository, QuestionBusinessRules questionBusinessRules)
    {
        _questionRepository = questionRepository;
        _questionBusinessRules = questionBusinessRules;
    }

    public async Task<Question?> GetAsync(
        Expression<Func<Question, bool>> predicate,
        Func<IQueryable<Question>, IIncludableQueryable<Question, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Question? question = await _questionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return question;
    }

    public async Task<IPaginate<Question>?> GetListAsync(
        Expression<Func<Question, bool>>? predicate = null,
        Func<IQueryable<Question>, IOrderedQueryable<Question>>? orderBy = null,
        Func<IQueryable<Question>, IIncludableQueryable<Question, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Question> questionList = await _questionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return questionList;
    }

    public async Task<Question> AddAsync(Question question)
    {
        Question addedQuestion = await _questionRepository.AddAsync(question);

        return addedQuestion;
    }

    public async Task<Question> UpdateAsync(Question question)
    {
        Question updatedQuestion = await _questionRepository.UpdateAsync(question);

        return updatedQuestion;
    }

    public async Task<Question> DeleteAsync(Question question, bool permanent = false)
    {
        Question deletedQuestion = await _questionRepository.DeleteAsync(question);

        return deletedQuestion;
    }
}
