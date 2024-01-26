using Application.Features.ImageExtensions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ImageExtensions.Constants.ImageExtensionsOperationClaims;

namespace Application.Features.ImageExtensions.Queries.GetList;

public class GetListImageExtensionQuery : IRequest<GetListResponse<GetListImageExtensionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListImageExtensions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetImageExtensions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListImageExtensionQueryHandler : IRequestHandler<GetListImageExtensionQuery, GetListResponse<GetListImageExtensionListItemDto>>
    {
        private readonly IImageExtensionRepository _imageExtensionRepository;
        private readonly IMapper _mapper;

        public GetListImageExtensionQueryHandler(IImageExtensionRepository imageExtensionRepository, IMapper mapper)
        {
            _imageExtensionRepository = imageExtensionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListImageExtensionListItemDto>> Handle(GetListImageExtensionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ImageExtension> imageExtensions = await _imageExtensionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListImageExtensionListItemDto> response = _mapper.Map<GetListResponse<GetListImageExtensionListItemDto>>(imageExtensions);
            return response;
        }
    }
}