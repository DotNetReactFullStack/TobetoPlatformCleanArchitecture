using Application.Features.Questions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Questions.Constants.QuestionsOperationClaims;

namespace Application.Features.Questions.Queries.GetList;

public class GetListQuestionQuery : IRequest<GetListResponse<GetListQuestionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListQuestions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetQuestions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, GetListResponse<GetListQuestionListItemDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuestionListItemDto>> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Question> questions = await _questionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuestionListItemDto> response = _mapper.Map<GetListResponse<GetListQuestionListItemDto>>(questions);
            return response;
        }
    }
}