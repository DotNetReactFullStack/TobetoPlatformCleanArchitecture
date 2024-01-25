using Application.Features.Experiences.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Experiences.Constants.ExperiencesOperationClaims;

namespace Application.Features.Experiences.Queries.GetList;

public class GetListExperienceQuery : IRequest<GetListResponse<GetListExperienceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListExperiences({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetExperiences";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListExperienceQueryHandler : IRequestHandler<GetListExperienceQuery, GetListResponse<GetListExperienceListItemDto>>
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public GetListExperienceQueryHandler(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExperienceListItemDto>> Handle(GetListExperienceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Experience> experiences = await _experienceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExperienceListItemDto> response = _mapper.Map<GetListResponse<GetListExperienceListItemDto>>(experiences);
            return response;
        }
    }
}