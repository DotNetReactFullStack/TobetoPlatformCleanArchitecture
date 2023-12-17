using Application.Features.RecourseSteps.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.RecourseSteps.Constants.RecourseStepsOperationClaims;

namespace Application.Features.RecourseSteps.Queries.GetList;

public class GetListRecourseStepQuery : IRequest<GetListResponse<GetListRecourseStepListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListRecourseSteps({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetRecourseSteps";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRecourseStepQueryHandler : IRequestHandler<GetListRecourseStepQuery, GetListResponse<GetListRecourseStepListItemDto>>
    {
        private readonly IRecourseStepRepository _recourseStepRepository;
        private readonly IMapper _mapper;

        public GetListRecourseStepQueryHandler(IRecourseStepRepository recourseStepRepository, IMapper mapper)
        {
            _recourseStepRepository = recourseStepRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRecourseStepListItemDto>> Handle(GetListRecourseStepQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RecourseStep> recourseSteps = await _recourseStepRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRecourseStepListItemDto> response = _mapper.Map<GetListResponse<GetListRecourseStepListItemDto>>(recourseSteps);
            return response;
        }
    }
}