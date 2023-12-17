using Application.Features.Recourses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Recourses.Constants.RecoursesOperationClaims;

namespace Application.Features.Recourses.Queries.GetList;

public class GetListRecourseQuery : IRequest<GetListResponse<GetListRecourseListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRecourses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRecourses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRecourseQueryHandler : IRequestHandler<GetListRecourseQuery, GetListResponse<GetListRecourseListItemDto>>
    {
        private readonly IRecourseRepository _recourseRepository;
        private readonly IMapper _mapper;

        public GetListRecourseQueryHandler(IRecourseRepository recourseRepository, IMapper mapper)
        {
            _recourseRepository = recourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRecourseListItemDto>> Handle(GetListRecourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Recourse> recourses = await _recourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRecourseListItemDto> response = _mapper.Map<GetListResponse<GetListRecourseListItemDto>>(recourses);
            return response;
        }
    }
}