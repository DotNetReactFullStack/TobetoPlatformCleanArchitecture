using Application.Features.LearningPaths.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.LearningPaths.Constants.LearningPathsOperationClaims;

namespace Application.Features.LearningPaths.Queries.GetList;

public class GetListLearningPathQuery : IRequest<GetListResponse<GetListLearningPathListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLearningPaths({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLearningPaths";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLearningPathQueryHandler : IRequestHandler<GetListLearningPathQuery, GetListResponse<GetListLearningPathListItemDto>>
    {
        private readonly ILearningPathRepository _learningPathRepository;
        private readonly IMapper _mapper;

        public GetListLearningPathQueryHandler(ILearningPathRepository learningPathRepository, IMapper mapper)
        {
            _learningPathRepository = learningPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLearningPathListItemDto>> Handle(GetListLearningPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LearningPath> learningPaths = await _learningPathRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLearningPathListItemDto> response = _mapper.Map<GetListResponse<GetListLearningPathListItemDto>>(learningPaths);
            return response;
        }
    }
}