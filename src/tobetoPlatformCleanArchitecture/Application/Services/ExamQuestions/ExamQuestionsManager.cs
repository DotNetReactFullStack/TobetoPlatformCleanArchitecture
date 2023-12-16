using Application.Features.ExamQuestions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamQuestions;

public class ExamQuestionsManager : IExamQuestionsService
{
    private readonly IExamQuestionRepository _examQuestionRepository;
    private readonly ExamQuestionBusinessRules _examQuestionBusinessRules;

    public ExamQuestionsManager(IExamQuestionRepository examQuestionRepository, ExamQuestionBusinessRules examQuestionBusinessRules)
    {
        _examQuestionRepository = examQuestionRepository;
        _examQuestionBusinessRules = examQuestionBusinessRules;
    }

    public async Task<ExamQuestion?> GetAsync(
        Expression<Func<ExamQuestion, bool>> predicate,
        Func<IQueryable<ExamQuestion>, IIncludableQueryable<ExamQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ExamQuestion? examQuestion = await _examQuestionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return examQuestion;
    }

    public async Task<IPaginate<ExamQuestion>?> GetListAsync(
        Expression<Func<ExamQuestion, bool>>? predicate = null,
        Func<IQueryable<ExamQuestion>, IOrderedQueryable<ExamQuestion>>? orderBy = null,
        Func<IQueryable<ExamQuestion>, IIncludableQueryable<ExamQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ExamQuestion> examQuestionList = await _examQuestionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return examQuestionList;
    }

    public async Task<ExamQuestion> AddAsync(ExamQuestion examQuestion)
    {
        ExamQuestion addedExamQuestion = await _examQuestionRepository.AddAsync(examQuestion);

        return addedExamQuestion;
    }

    public async Task<ExamQuestion> UpdateAsync(ExamQuestion examQuestion)
    {
        ExamQuestion updatedExamQuestion = await _examQuestionRepository.UpdateAsync(examQuestion);

        return updatedExamQuestion;
    }

    public async Task<ExamQuestion> DeleteAsync(ExamQuestion examQuestion, bool permanent = false)
    {
        ExamQuestion deletedExamQuestion = await _examQuestionRepository.DeleteAsync(examQuestion);

        return deletedExamQuestion;
    }
}
