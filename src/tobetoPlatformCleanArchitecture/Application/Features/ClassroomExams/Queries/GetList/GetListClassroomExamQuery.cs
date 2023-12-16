using Application.Features.ClassroomExams.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ClassroomExams.Constants.ClassroomExamsOperationClaims;

namespace Application.Features.ClassroomExams.Queries.GetList;

public class GetListClassroomExamQuery : IRequest<GetListResponse<GetListClassroomExamListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListClassroomExams({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetClassroomExams";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListClassroomExamQueryHandler : IRequestHandler<GetListClassroomExamQuery, GetListResponse<GetListClassroomExamListItemDto>>
    {
        private readonly IClassroomExamRepository _classroomExamRepository;
        private readonly IMapper _mapper;

        public GetListClassroomExamQueryHandler(IClassroomExamRepository classroomExamRepository, IMapper mapper)
        {
            _classroomExamRepository = classroomExamRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassroomExamListItemDto>> Handle(GetListClassroomExamQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ClassroomExam> classroomExams = await _classroomExamRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassroomExamListItemDto> response = _mapper.Map<GetListResponse<GetListClassroomExamListItemDto>>(classroomExams);
            return response;
        }
    }
}