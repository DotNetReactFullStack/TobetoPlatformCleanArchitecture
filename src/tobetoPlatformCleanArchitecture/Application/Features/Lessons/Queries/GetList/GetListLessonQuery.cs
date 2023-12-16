using Application.Features.Lessons.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;

namespace Application.Features.Lessons.Queries.GetList;

public class GetListLessonQuery : IRequest<GetListResponse<GetListLessonListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQuery, GetListResponse<GetListLessonListItemDto>>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonListItemDto>> Handle(GetListLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonListItemDto> response = _mapper.Map<GetListResponse<GetListLessonListItemDto>>(lessons);
            return response;
        }
    }
}