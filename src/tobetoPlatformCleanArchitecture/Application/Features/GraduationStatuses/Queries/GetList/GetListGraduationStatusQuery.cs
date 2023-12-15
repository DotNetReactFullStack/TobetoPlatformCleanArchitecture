using Application.Features.GraduationStatuses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.GraduationStatuses.Constants.GraduationStatusesOperationClaims;

namespace Application.Features.GraduationStatuses.Queries.GetList;

public class GetListGraduationStatusQuery : IRequest<GetListResponse<GetListGraduationStatusListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListGraduationStatus({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetGraduationStatus";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListGraduationStatusQueryHandler : IRequestHandler<GetListGraduationStatusQuery, GetListResponse<GetListGraduationStatusListItemDto>>
    {
        private readonly IGraduationStatusRepository _graduationStatusRepository;
        private readonly IMapper _mapper;

        public GetListGraduationStatusQueryHandler(IGraduationStatusRepository graduationStatusRepository, IMapper mapper)
        {
            _graduationStatusRepository = graduationStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGraduationStatusListItemDto>> Handle(GetListGraduationStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GraduationStatus> graduationStatus = await _graduationStatusRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGraduationStatusListItemDto> response = _mapper.Map<GetListResponse<GetListGraduationStatusListItemDto>>(graduationStatus);
            return response;
        }
    }
}