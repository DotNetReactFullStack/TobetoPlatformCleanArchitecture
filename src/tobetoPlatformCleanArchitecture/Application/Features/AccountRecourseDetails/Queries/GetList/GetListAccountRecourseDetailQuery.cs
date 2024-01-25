using Application.Features.AccountRecourseDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AccountRecourseDetails.Constants.AccountRecourseDetailsOperationClaims;

namespace Application.Features.AccountRecourseDetails.Queries.GetList;

public class GetListAccountRecourseDetailQuery : IRequest<GetListResponse<GetListAccountRecourseDetailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAccountRecourseDetails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAccountRecourseDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAccountRecourseDetailQueryHandler : IRequestHandler<GetListAccountRecourseDetailQuery, GetListResponse<GetListAccountRecourseDetailListItemDto>>
    {
        private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
        private readonly IMapper _mapper;

        public GetListAccountRecourseDetailQueryHandler(IAccountRecourseDetailRepository accountRecourseDetailRepository, IMapper mapper)
        {
            _accountRecourseDetailRepository = accountRecourseDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAccountRecourseDetailListItemDto>> Handle(GetListAccountRecourseDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AccountRecourseDetail> accountRecourseDetails = await _accountRecourseDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAccountRecourseDetailListItemDto> response = _mapper.Map<GetListResponse<GetListAccountRecourseDetailListItemDto>>(accountRecourseDetails);
            return response;
        }
    }
}