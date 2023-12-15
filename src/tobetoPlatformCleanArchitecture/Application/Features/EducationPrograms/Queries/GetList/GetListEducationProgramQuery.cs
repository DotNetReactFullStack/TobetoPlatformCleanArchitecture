using Application.Features.EducationPrograms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.EducationPrograms.Constants.EducationProgramsOperationClaims;

namespace Application.Features.EducationPrograms.Queries.GetList;

public class GetListEducationProgramQuery : IRequest<GetListResponse<GetListEducationProgramListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListEducationPrograms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetEducationPrograms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEducationProgramQueryHandler : IRequestHandler<GetListEducationProgramQuery, GetListResponse<GetListEducationProgramListItemDto>>
    {
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly IMapper _mapper;

        public GetListEducationProgramQueryHandler(IEducationProgramRepository educationProgramRepository, IMapper mapper)
        {
            _educationProgramRepository = educationProgramRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEducationProgramListItemDto>> Handle(GetListEducationProgramQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationProgram> educationPrograms = await _educationProgramRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEducationProgramListItemDto> response = _mapper.Map<GetListResponse<GetListEducationProgramListItemDto>>(educationPrograms);
            return response;
        }
    }
}