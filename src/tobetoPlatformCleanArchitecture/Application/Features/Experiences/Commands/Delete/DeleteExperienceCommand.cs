using Application.Features.Experiences.Constants;
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

namespace Application.Features.Experiences.Commands.Delete;

public class DeleteExperienceCommand : IRequest<DeletedExperienceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ExperiencesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExperiences";

    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, DeletedExperienceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public DeleteExperienceCommandHandler(IMapper mapper, IExperienceRepository experienceRepository,
                                         ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<DeletedExperienceResponse> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);

            await _experienceRepository.DeleteAsync(experience!);

            DeletedExperienceResponse response = _mapper.Map<DeletedExperienceResponse>(experience);
            return response;
        }
    }
}