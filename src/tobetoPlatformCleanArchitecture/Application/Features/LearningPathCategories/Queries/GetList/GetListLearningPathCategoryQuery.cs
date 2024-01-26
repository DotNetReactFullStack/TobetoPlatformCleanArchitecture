using Application.Features.LearningPathCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.LearningPathCategories.Constants.LearningPathCategoriesOperationClaims;

namespace Application.Features.LearningPathCategories.Queries.GetList;

public class GetListLearningPathCategoryQuery : IRequest<GetListResponse<GetListLearningPathCategoryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLearningPathCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLearningPathCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLearningPathCategoryQueryHandler : IRequestHandler<GetListLearningPathCategoryQuery, GetListResponse<GetListLearningPathCategoryListItemDto>>
    {
        private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
        private readonly IMapper _mapper;

        public GetListLearningPathCategoryQueryHandler(ILearningPathCategoryRepository learningPathCategoryRepository, IMapper mapper)
        {
            _learningPathCategoryRepository = learningPathCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLearningPathCategoryListItemDto>> Handle(GetListLearningPathCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LearningPathCategory> learningPathCategories = await _learningPathCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLearningPathCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListLearningPathCategoryListItemDto>>(learningPathCategories);
            return response;
        }
    }
}