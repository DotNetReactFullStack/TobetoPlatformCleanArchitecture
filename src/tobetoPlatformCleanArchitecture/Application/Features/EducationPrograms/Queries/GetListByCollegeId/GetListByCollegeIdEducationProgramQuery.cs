using Application.Features.EducationPrograms.Queries.GetList;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;


using static Application.Features.EducationPrograms.Constants.EducationProgramsOperationClaims;

namespace Application.Features.EducationPrograms.Queries.GetListByCollegeId;
public class GetListByCollegeIdEducationProgramQuery : IRequest<GetListResponse<GetListByCollegeIdEducationProgramListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public int CollegeId { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public class GetListByCollegeIdEducationProgramQueryHandler : IRequestHandler<GetListByCollegeIdEducationProgramQuery, GetListResponse<GetListByCollegeIdEducationProgramListItemDto>>
    {
        private readonly IEducationProgramRepository _educationProgramRepository;
        private readonly IMapper _mapper;

        public GetListByCollegeIdEducationProgramQueryHandler(IEducationProgramRepository educationProgramRepository, IMapper mapper)
        {
            _educationProgramRepository = educationProgramRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListByCollegeIdEducationProgramListItemDto>> Handle(GetListByCollegeIdEducationProgramQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EducationProgram> educationPrograms = await _educationProgramRepository.GetListAsync(
                predicate: ep => ep.CollegeId == request.CollegeId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByCollegeIdEducationProgramListItemDto> response = _mapper.Map<GetListResponse<GetListByCollegeIdEducationProgramListItemDto>>(educationPrograms);
            return response;
        }

      
    }
}
