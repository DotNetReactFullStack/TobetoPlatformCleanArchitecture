using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Exams;

public interface IExamsService
{
    Task<Exam?> GetAsync(
        Expression<Func<Exam, bool>> predicate,
        Func<IQueryable<Exam>, IIncludableQueryable<Exam, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Exam>?> GetListAsync(
        Expression<Func<Exam, bool>>? predicate = null,
        Func<IQueryable<Exam>, IOrderedQueryable<Exam>>? orderBy = null,
        Func<IQueryable<Exam>, IIncludableQueryable<Exam, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Exam> AddAsync(Exam exam);
    Task<Exam> UpdateAsync(Exam exam);
    Task<Exam> DeleteAsync(Exam exam, bool permanent = false);
}
