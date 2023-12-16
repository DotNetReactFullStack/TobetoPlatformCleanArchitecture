using Application.Features.QuestionCategories.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.QuestionCategories.Constants.QuestionCategoriesOperationClaims;

namespace Application.Features.QuestionCategories.Queries.GetList;

public class GetListQuestionCategoryQuery : IRequest<GetListResponse<GetListQuestionCategoryListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListQuestionCategories({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetQuestionCategories";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListQuestionCategoryQueryHandler : IRequestHandler<GetListQuestionCategoryQuery, GetListResponse<GetListQuestionCategoryListItemDto>>
    {
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly IMapper _mapper;

        public GetListQuestionCategoryQueryHandler(IQuestionCategoryRepository questionCategoryRepository, IMapper mapper)
        {
            _questionCategoryRepository = questionCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionCategoryListItemDto>> Handle(GetListQuestionCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<QuestionCategory> questionCategories = await _questionCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuestionCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListQuestionCategoryListItemDto>>(questionCategories);
            return response;
        }
    }
}