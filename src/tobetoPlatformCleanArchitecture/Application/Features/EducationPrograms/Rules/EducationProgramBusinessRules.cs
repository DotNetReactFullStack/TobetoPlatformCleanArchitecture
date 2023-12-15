using Application.Features.EducationPrograms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.EducationPrograms.Rules;

public class EducationProgramBusinessRules : BaseBusinessRules
{
    private readonly IEducationProgramRepository _educationProgramRepository;

    public EducationProgramBusinessRules(IEducationProgramRepository educationProgramRepository)
    {
        _educationProgramRepository = educationProgramRepository;
    }

    public Task EducationProgramShouldExistWhenSelected(EducationProgram? educationProgram)
    {
        if (educationProgram == null)
            throw new BusinessException(EducationProgramsBusinessMessages.EducationProgramNotExists);
        return Task.CompletedTask;
    }

    public async Task EducationProgramIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        EducationProgram? educationProgram = await _educationProgramRepository.GetAsync(
            predicate: ep => ep.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EducationProgramShouldExistWhenSelected(educationProgram);
    }
}