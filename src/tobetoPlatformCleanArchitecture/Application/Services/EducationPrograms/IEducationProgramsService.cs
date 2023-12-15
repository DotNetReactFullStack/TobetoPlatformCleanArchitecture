using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationPrograms;

public interface IEducationProgramsService
{
    Task<EducationProgram?> GetAsync(
        Expression<Func<EducationProgram, bool>> predicate,
        Func<IQueryable<EducationProgram>, IIncludableQueryable<EducationProgram, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EducationProgram>?> GetListAsync(
        Expression<Func<EducationProgram, bool>>? predicate = null,
        Func<IQueryable<EducationProgram>, IOrderedQueryable<EducationProgram>>? orderBy = null,
        Func<IQueryable<EducationProgram>, IIncludableQueryable<EducationProgram, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EducationProgram> AddAsync(EducationProgram educationProgram);
    Task<EducationProgram> UpdateAsync(EducationProgram educationProgram);
    Task<EducationProgram> DeleteAsync(EducationProgram educationProgram, bool permanent = false);
}
