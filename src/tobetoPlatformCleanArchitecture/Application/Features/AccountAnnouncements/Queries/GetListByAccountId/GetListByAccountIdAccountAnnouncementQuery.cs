using Application.Features.AccountAnnouncements.Queries.GetList;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using static Application.Features.AccountAnnouncements.Constants.AccountAnnouncementsOperationClaims;

namespace Application.Features.AccountAnnouncements.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountAnnouncementQuery : IRequest<GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>>, ISecuredRequest, ICachableRequest
    {
        public int AccountId { get; set; }

        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

        public bool BypassCache { get; }
        public string CacheKey => $"GetListByAccountId({AccountId})AccountAnnouncements({PageRequest.PageIndex},{PageRequest.PageSize})";
        public string CacheGroupKey => "GetAccountAnnouncements";
        public TimeSpan? SlidingExpiration { get; }

        public class GetListByAccountIdAccountAnnouncementQueryHandler : IRequestHandler<GetListByAccountIdAccountAnnouncementQuery, GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>>
        {
            private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
            private readonly IMapper _mapper;

            public GetListByAccountIdAccountAnnouncementQueryHandler(IAccountAnnouncementRepository accountAnnouncementRepository, IMapper mapper)
            {
                _accountAnnouncementRepository = accountAnnouncementRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>> Handle(GetListByAccountIdAccountAnnouncementQuery request, CancellationToken cancellationToken)
            {
                IPaginate<AccountAnnouncement> accountAnnouncements = await _accountAnnouncementRepository.GetListAsync(
                    predicate: (aa => aa.AccountId == request.AccountId),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken,
                    include:aa=>aa.Include(aa=>aa.Announcement.AnnouncementType)
                                  .Include(aa=>aa.Announcement.Organization)
                );

                GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>>(accountAnnouncements);
                return response;
            }
        }
    }
}

