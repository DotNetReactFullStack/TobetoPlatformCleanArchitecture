using Application.Features.AccountAnnouncements.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountAnnouncements.Constants.AccountAnnouncementsOperationClaims;

namespace Application.Features.AccountAnnouncements.Queries.GetList;

public class GetListAccountAnnouncementQuery : IRequest<GetListResponse<GetListAccountAnnouncementListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountAnnouncements({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountAnnouncements";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountAnnouncementQueryHandler : IRequestHandler<GetListAccountAnnouncementQuery, GetListResponse<GetListAccountAnnouncementListItemDto>>
    {
        private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
        private readonly IMapper _mapper;

        public GetListAccountAnnouncementQueryHandler(IAccountAnnouncementRepository accountAnnouncementRepository, IMapper mapper)
        {
            _accountAnnouncementRepository = accountAnnouncementRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountAnnouncementListItemDto>> Handle(GetListAccountAnnouncementQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountAnnouncement> accountAnnouncements = await _accountAnnouncementRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountAnnouncementListItemDto> response = _mapper.Map<GetListResponse<GetListAccountAnnouncementListItemDto>>(accountAnnouncements);
            return response;
        }
    }
}