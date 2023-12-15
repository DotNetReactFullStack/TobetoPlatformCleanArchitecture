using Application.Features.EducationPrograms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EducationPrograms;

public class EducationProgramsManager : IEducationProgramsService
{
    private readonly IEducationProgramRepository _educationProgramRepository;
    private readonly EducationProgramBusinessRules _educationProgramBusinessRules;

    public EducationProgramsManager(IEducationProgramRepository educationProgramRepository, EducationProgramBusinessRules educationProgramBusinessRules)
    {
        _educationProgramRepository = educationProgramRepository;
        _educationProgramBusinessRules = educationProgramBusinessRules;
    }

    public async Task<EducationProgram?> GetAsync(
        Expression<Func<EducationProgram, bool>> predicate,
        Func<IQueryable<EducationProgram>, IIncludableQueryable<EducationProgram, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EducationProgram? educationProgram = await _educationProgramRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return educationProgram;
    }

    public async Task<IPaginate<EducationProgram>?> GetListAsync(
        Expression<Func<EducationProgram, bool>>? predicate = null,
        Func<IQueryable<EducationProgram>, IOrderedQueryable<EducationProgram>>? orderBy = null,
        Func<IQueryable<EducationProgram>, IIncludableQueryable<EducationProgram, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EducationProgram> educationProgramList = await _educationProgramRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return educationProgramList;
    }

    public async Task<EducationProgram> AddAsync(EducationProgram educationProgram)
    {
        EducationProgram addedEducationProgram = await _educationProgramRepository.AddAsync(educationProgram);

        return addedEducationProgram;
    }

    public async Task<EducationProgram> UpdateAsync(EducationProgram educationProgram)
    {
        EducationProgram updatedEducationProgram = await _educationProgramRepository.UpdateAsync(educationProgram);

        return updatedEducationProgram;
    }

    public async Task<EducationProgram> DeleteAsync(EducationProgram educationProgram, bool permanent = false)
    {
        EducationProgram deletedEducationProgram = await _educationProgramRepository.DeleteAsync(educationProgram);

        return deletedEducationProgram;
    }
}
