using Application.Features.Announcements.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Announcements.Constants.AnnouncementsOperationClaims;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementQuery : IRequest<GetListResponse<GetListAnnouncementListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAnnouncements({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAnnouncements";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAnnouncementQueryHandler : IRequestHandler<GetListAnnouncementQuery, GetListResponse<GetListAnnouncementListItemDto>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;

        public GetListAnnouncementQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAnnouncementListItemDto>> Handle(GetListAnnouncementQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Announcement> announcements = await _announcementRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAnnouncementListItemDto> response = _mapper.Map<GetListResponse<GetListAnnouncementListItemDto>>(announcements);
            return response;
        }
    }
}