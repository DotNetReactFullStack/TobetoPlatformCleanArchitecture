using Application.Features.AnnouncementTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AnnouncementTypes.Constants.AnnouncementTypesOperationClaims;

namespace Application.Features.AnnouncementTypes.Queries.GetList;

public class GetListAnnouncementTypeQuery : IRequest<GetListResponse<GetListAnnouncementTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAnnouncementTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAnnouncementTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAnnouncementTypeQueryHandler : IRequestHandler<GetListAnnouncementTypeQuery, GetListResponse<GetListAnnouncementTypeListItemDto>>
    {
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly IMapper _mapper;

        public GetListAnnouncementTypeQueryHandler(IAnnouncementTypeRepository announcementTypeRepository, IMapper mapper)
        {
            _announcementTypeRepository = announcementTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAnnouncementTypeListItemDto>> Handle(GetListAnnouncementTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AnnouncementType> announcementTypes = await _announcementTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAnnouncementTypeListItemDto> response = _mapper.Map<GetListResponse<GetListAnnouncementTypeListItemDto>>(announcementTypes);
            return response;
        }
    }
}