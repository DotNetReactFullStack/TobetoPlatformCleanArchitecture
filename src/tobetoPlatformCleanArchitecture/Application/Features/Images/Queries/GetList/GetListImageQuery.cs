using Application.Features.Images.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Images.Constants.ImagesOperationClaims;

namespace Application.Features.Images.Queries.GetList;

public class GetListImageQuery : IRequest<GetListResponse<GetListImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListImageQueryHandler : IRequestHandler<GetListImageQuery, GetListResponse<GetListImageListItemDto>>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public GetListImageQueryHandler(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListImageListItemDto>> Handle(GetListImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Image> images = await _imageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListImageListItemDto> response = _mapper.Map<GetListResponse<GetListImageListItemDto>>(images);
            return response;
        }
    }
}