using Application.Features.Experiences.Constants;
using Application.Features.Experiences.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Experiences.Constants.ExperiencesOperationClaims;

namespace Application.Features.Experiences.Commands.Create;

public class CreateExperienceCommand : IRequest<CreatedExperienceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int CityId { get; set; }
    public string CompanyName { get; set; }
    public string JobTitle { get; set; }
    public string Industry { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public bool IsCurrentlyWorking { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ExperiencesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExperiences";

    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, CreatedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public CreateExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<CreatedExperienceResponse> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience experience = _mapper.Map<Experience>(request);

            await _experienceRepository.AddAsync(experience);

            CreatedExperienceResponse response = _mapper.Map<CreatedExperienceResponse>(experience);
            return response;
        }
    }
}