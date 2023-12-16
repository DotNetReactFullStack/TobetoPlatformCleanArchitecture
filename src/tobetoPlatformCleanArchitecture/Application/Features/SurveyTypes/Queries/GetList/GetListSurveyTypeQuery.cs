using Application.Features.SurveyTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.SurveyTypes.Constants.SurveyTypesOperationClaims;

namespace Application.Features.SurveyTypes.Queries.GetList;

public class GetListSurveyTypeQuery : IRequest<GetListResponse<GetListSurveyTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSurveyTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSurveyTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSurveyTypeQueryHandler : IRequestHandler<GetListSurveyTypeQuery, GetListResponse<GetListSurveyTypeListItemDto>>
    {
        private readonly ISurveyTypeRepository _surveyTypeRepository;
        private readonly IMapper _mapper;

        public GetListSurveyTypeQueryHandler(ISurveyTypeRepository surveyTypeRepository, IMapper mapper)
        {
            _surveyTypeRepository = surveyTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSurveyTypeListItemDto>> Handle(GetListSurveyTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SurveyType> surveyTypes = await _surveyTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSurveyTypeListItemDto> response = _mapper.Map<GetListResponse<GetListSurveyTypeListItemDto>>(surveyTypes);
            return response;
        }
    }
}