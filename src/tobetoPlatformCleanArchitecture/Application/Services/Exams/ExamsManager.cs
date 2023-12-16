using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Exams;

public class ExamsManager : IExamsService
{
    private readonly IExamRepository _examRepository;
    private readonly ExamBusinessRules _examBusinessRules;

    public ExamsManager(IExamRepository examRepository, ExamBusinessRules examBusinessRules)
    {
        _examRepository = examRepository;
        _examBusinessRules = examBusinessRules;
    }

    public async Task<Exam?> GetAsync(
        Expression<Func<Exam, bool>> predicate,
        Func<IQueryable<Exam>, IIncludableQueryable<Exam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Exam? exam = await _examRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return exam;
    }

    public async Task<IPaginate<Exam>?> GetListAsync(
        Expression<Func<Exam, bool>>? predicate = null,
        Func<IQueryable<Exam>, IOrderedQueryable<Exam>>? orderBy = null,
        Func<IQueryable<Exam>, IIncludableQueryable<Exam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Exam> examList = await _examRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return examList;
    }

    public async Task<Exam> AddAsync(Exam exam)
    {
        Exam addedExam = await _examRepository.AddAsync(exam);

        return addedExam;
    }

    public async Task<Exam> UpdateAsync(Exam exam)
    {
        Exam updatedExam = await _examRepository.UpdateAsync(exam);

        return updatedExam;
    }

    public async Task<Exam> DeleteAsync(Exam exam, bool permanent = false)
    {
        Exam deletedExam = await _examRepository.DeleteAsync(exam);

        return deletedExam;
    }
}
