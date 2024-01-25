using Application.Features.RecourseDetailSteps.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RecourseDetailSteps.Constants.RecourseDetailStepsOperationClaims;

namespace Application.Features.RecourseDetailSteps.Queries.GetList;

public class GetListRecourseDetailStepQuery : IRequest<GetListResponse<GetListRecourseDetailStepListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRecourseDetailSteps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRecourseDetailSteps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRecourseDetailStepQueryHandler : IRequestHandler<GetListRecourseDetailStepQuery, GetListResponse<GetListRecourseDetailStepListItemDto>>
    {
        private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
        private readonly IMapper _mapper;

        public GetListRecourseDetailStepQueryHandler(IRecourseDetailStepRepository recourseDetailStepRepository, IMapper mapper)
        {
            _recourseDetailStepRepository = recourseDetailStepRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRecourseDetailStepListItemDto>> Handle(GetListRecourseDetailStepQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RecourseDetailStep> recourseDetailSteps = await _recourseDetailStepRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRecourseDetailStepListItemDto> response = _mapper.Map<GetListResponse<GetListRecourseDetailStepListItemDto>>(recourseDetailSteps);
            return response;
        }
    }
}