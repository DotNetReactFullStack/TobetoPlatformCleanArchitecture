using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ExamQuestions;

public interface IExamQuestionsService
{
    Task<ExamQuestion?> GetAsync(
        Expression<Func<ExamQuestion, bool>> predicate,
        Func<IQueryable<ExamQuestion>, IIncludableQueryable<ExamQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ExamQuestion>?> GetListAsync(
        Expression<Func<ExamQuestion, bool>>? predicate = null,
        Func<IQueryable<ExamQuestion>, IOrderedQueryable<ExamQuestion>>? orderBy = null,
        Func<IQueryable<ExamQuestion>, IIncludableQueryable<ExamQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ExamQuestion> AddAsync(ExamQuestion examQuestion);
    Task<ExamQuestion> UpdateAsync(ExamQuestion examQuestion);
    Task<ExamQuestion> DeleteAsync(ExamQuestion examQuestion, bool permanent = false);
}
