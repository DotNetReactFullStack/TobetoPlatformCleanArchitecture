using Application.Features.AccountCapabilities.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using static Application.Features.AccountCapabilities.Constants.AccountCapabilitiesOperationClaims;
using System;
using Application.Features.OperationClaims.Constants;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AccountCapabilities.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountCapabilityQuery : IRequest<GetListResponse<GetListByAccountIdAccountCapabilityListItemDto>>, ISecuredRequest, ICachableRequest
    {
        public int? Id { get; set; }
        public int AccountId { get; set; }

        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

        public bool BypassCache { get; }
        public string CacheKey => $"GetListByAccountIdAccountCapabilities({PageRequest.PageIndex},{PageRequest.PageSize})";
        public string CacheGroupKey => "GetAccountCapabilities";
        public TimeSpan? SlidingExpiration { get; }

        public class GetListByAccountIdAccountCapabilityQueryHandler : IRequestHandler<GetListByAccountIdAccountCapabilityQuery, GetListResponse<GetListByAccountIdAccountCapabilityListItemDto>>
        {
            private readonly IAccountCapabilityRepository _accountCapabilityRepository;
            private readonly IMapper _mapper;

            public GetListByAccountIdAccountCapabilityQueryHandler(IAccountCapabilityRepository accountCapabilityRepository, IMapper mapper)
            {
                _accountCapabilityRepository = accountCapabilityRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByAccountIdAccountCapabilityListItemDto>> Handle(GetListByAccountIdAccountCapabilityQuery request, CancellationToken cancellationToken)
            {
                IPaginate<AccountCapability> accountCapabilities = await _accountCapabilityRepository.GetListAsync(
                    predicate: (ac=>ac.AccountId == request.AccountId),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken,
                    include:ac=>ac.Include(p=>p.Capability)
                    //.Include(p => p.Capability)
                );

                GetListResponse<GetListByAccountIdAccountCapabilityListItemDto> response = _mapper.Map<GetListResponse<GetListByAccountIdAccountCapabilityListItemDto>>(accountCapabilities);
                return response;
            }
        }
    }
}

