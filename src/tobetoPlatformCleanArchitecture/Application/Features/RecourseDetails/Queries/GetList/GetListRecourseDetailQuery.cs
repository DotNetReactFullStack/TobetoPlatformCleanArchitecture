using Application.Features.RecourseDetails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RecourseDetails.Constants.RecourseDetailsOperationClaims;

namespace Application.Features.RecourseDetails.Queries.GetList;

public class GetListRecourseDetailQuery : IRequest<GetListResponse<GetListRecourseDetailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRecourseDetails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRecourseDetails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRecourseDetailQueryHandler : IRequestHandler<GetListRecourseDetailQuery, GetListResponse<GetListRecourseDetailListItemDto>>
    {
        private readonly IRecourseDetailRepository _recourseDetailRepository;
        private readonly IMapper _mapper;

        public GetListRecourseDetailQueryHandler(IRecourseDetailRepository recourseDetailRepository, IMapper mapper)
        {
            _recourseDetailRepository = recourseDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRecourseDetailListItemDto>> Handle(GetListRecourseDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RecourseDetail> recourseDetails = await _recourseDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRecourseDetailListItemDto> response = _mapper.Map<GetListResponse<GetListRecourseDetailListItemDto>>(recourseDetails);
            return response;
        }
    }
}