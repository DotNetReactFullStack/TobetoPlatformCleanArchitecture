using Application.Features.ForeignLanguageLevels.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ForeignLanguageLevels.Constants.ForeignLanguageLevelsOperationClaims;

namespace Application.Features.ForeignLanguageLevels.Queries.GetList;

public class GetListForeignLanguageLevelQuery : IRequest<GetListResponse<GetListForeignLanguageLevelListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListForeignLanguageLevels({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetForeignLanguageLevels";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListForeignLanguageLevelQueryHandler : IRequestHandler<GetListForeignLanguageLevelQuery, GetListResponse<GetListForeignLanguageLevelListItemDto>>
    {
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly IMapper _mapper;

        public GetListForeignLanguageLevelQueryHandler(IForeignLanguageLevelRepository foreignLanguageLevelRepository, IMapper mapper)
        {
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListForeignLanguageLevelListItemDto>> Handle(GetListForeignLanguageLevelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ForeignLanguageLevel> foreignLanguageLevels = await _foreignLanguageLevelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListForeignLanguageLevelListItemDto> response = _mapper.Map<GetListResponse<GetListForeignLanguageLevelListItemDto>>(foreignLanguageLevels);
            return response;
        }
    }
}