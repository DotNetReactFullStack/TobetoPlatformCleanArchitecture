using Application.Features.Colleges.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Colleges.Constants.CollegesOperationClaims;

namespace Application.Features.Colleges.Queries.GetList;

public class GetListCollegeQuery : IRequest<GetListResponse<GetListCollegeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListColleges({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetColleges";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCollegeQueryHandler : IRequestHandler<GetListCollegeQuery, GetListResponse<GetListCollegeListItemDto>>
    {
        private readonly ICollegeRepository _collegeRepository;
        private readonly IMapper _mapper;

        public GetListCollegeQueryHandler(ICollegeRepository collegeRepository, IMapper mapper)
        {
            _collegeRepository = collegeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCollegeListItemDto>> Handle(GetListCollegeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<College> colleges = await _collegeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCollegeListItemDto> response = _mapper.Map<GetListResponse<GetListCollegeListItemDto>>(colleges);
            return response;
        }
    }
}