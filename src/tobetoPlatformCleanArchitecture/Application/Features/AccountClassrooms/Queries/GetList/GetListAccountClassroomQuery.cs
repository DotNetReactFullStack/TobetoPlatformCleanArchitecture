using Application.Features.AccountClassrooms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountClassrooms.Constants.AccountClassroomsOperationClaims;

namespace Application.Features.AccountClassrooms.Queries.GetList;

public class GetListAccountClassroomQuery : IRequest<GetListResponse<GetListAccountClassroomListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountClassrooms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountClassrooms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountClassroomQueryHandler : IRequestHandler<GetListAccountClassroomQuery, GetListResponse<GetListAccountClassroomListItemDto>>
    {
        private readonly IAccountClassroomRepository _accountClassroomRepository;
        private readonly IMapper _mapper;

        public GetListAccountClassroomQueryHandler(IAccountClassroomRepository accountClassroomRepository, IMapper mapper)
        {
            _accountClassroomRepository = accountClassroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountClassroomListItemDto>> Handle(GetListAccountClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountClassroom> accountClassrooms = await _accountClassroomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListAccountClassroomListItemDto>>(accountClassrooms);
            return response;
        }
    }
}