
using Application.Features.Lessons.Queries.GetList;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;

namespace Application.Features.Lessons.Queries.GetListByCourseId;
public class GetListByCourseIdLessonQuery : IRequest<GetListResponse<GetListByCourseIdLessonListItemDto>>, ISecuredRequest, ICachableRequest
{ 
    public int CourseId { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };
    public bool BypassCache { get; }
    public string CacheKey => $"GetListByCourseId({CourseId})Lessons({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLessons";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListByCourseIdLessonQueryHandler : IRequestHandler<GetListByCourseIdLessonQuery, GetListResponse<GetListByCourseIdLessonListItemDto>>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public GetListByCourseIdLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByCourseIdLessonListItemDto>> Handle(GetListByCourseIdLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByCourseIdLessonListItemDto> response = _mapper.Map<GetListResponse<GetListByCourseIdLessonListItemDto>>(lessons);
            return response;
        }
    }
}
