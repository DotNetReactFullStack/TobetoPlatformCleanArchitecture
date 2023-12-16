using Application.Features.Answers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Answers.Constants.AnswersOperationClaims;

namespace Application.Features.Answers.Queries.GetList;

public class GetListAnswerQuery : IRequest<GetListResponse<GetListAnswerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAnswers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAnswers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAnswerQueryHandler : IRequestHandler<GetListAnswerQuery, GetListResponse<GetListAnswerListItemDto>>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public GetListAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAnswerListItemDto>> Handle(GetListAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Answer> answers = await _answerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListAnswerListItemDto>>(answers);
            return response;
        }
    }
}