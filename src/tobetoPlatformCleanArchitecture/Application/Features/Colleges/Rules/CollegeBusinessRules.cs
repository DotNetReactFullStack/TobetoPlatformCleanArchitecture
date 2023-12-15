using Application.Features.Colleges.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Colleges.Rules;

public class CollegeBusinessRules : BaseBusinessRules
{
    private readonly ICollegeRepository _collegeRepository;

    public CollegeBusinessRules(ICollegeRepository collegeRepository)
    {
        _collegeRepository = collegeRepository;
    }

    public Task CollegeShouldExistWhenSelected(College? college)
    {
        if (college == null)
            throw new BusinessException(CollegesBusinessMessages.CollegeNotExists);
        return Task.CompletedTask;
    }

    public async Task CollegeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        College? college = await _collegeRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CollegeShouldExistWhenSelected(college);
    }
}