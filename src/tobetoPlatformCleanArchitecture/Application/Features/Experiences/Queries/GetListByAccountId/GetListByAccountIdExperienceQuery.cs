using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;

namespace Application.Features.Experiences.Queries.GetListByAccountId;
public class GetListByAccountIdExperienceQuery : IRequest<GetListResponse<GetListByAccountIdExperienceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public int? Id { get; set; }
    public int AccountId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListExperiences({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetExperiences";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByAccountIdExperienceQueryHandler : IRequestHandler<GetListByAccountIdExperienceQuery, GetListResponse<GetListByAccountIdExperienceListItemDto>>
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public GetListByAccountIdExperienceQueryHandler(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByAccountIdExperienceListItemDto>> Handle(GetListByAccountIdExperienceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Experience> experiences = await _experienceRepository.GetListAsync(
                predicate: e => e.AccountId == request.AccountId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByAccountIdExperienceListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdExperienceListItemDto>>(experiences);
            return response;
        }
    }
}
