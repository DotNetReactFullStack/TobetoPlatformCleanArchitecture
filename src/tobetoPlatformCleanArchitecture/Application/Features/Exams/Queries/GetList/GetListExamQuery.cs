using Application.Features.Exams.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Exams.Constants.ExamsOperationClaims;

namespace Application.Features.Exams.Queries.GetList;

public class GetListExamQuery : IRequest<GetListResponse<GetListExamListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListExams({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetExams";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListExamQueryHandler : IRequestHandler<GetListExamQuery, GetListResponse<GetListExamListItemDto>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public GetListExamQueryHandler(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExamListItemDto>> Handle(GetListExamQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Exam> exams = await _examRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExamListItemDto> response = _mapper.Map<GetListResponse<GetListExamListItemDto>>(exams);
            return response;
        }
    }
}