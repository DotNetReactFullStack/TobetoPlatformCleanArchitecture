using Application.Features.ImageExtensions.Constants;
using Application.Features.ImageExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ImageExtensions.Constants.ImageExtensionsOperationClaims;

namespace Application.Features.ImageExtensions.Queries.GetById;

public class GetByIdImageExtensionQuery : IRequest<GetByIdImageExtensionResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdImageExtensionQueryHandler : IRequestHandler<GetByIdImageExtensionQuery, GetByIdImageExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageExtensionRepository _imageExtensionRepository;
        private readonly ImageExtensionBusinessRules _imageExtensionBusinessRules;

        public GetByIdImageExtensionQueryHandler(IMapper mapper, IImageExtensionRepository imageExtensionRepository, ImageExtensionBusinessRules imageExtensionBusinessRules)
        {
            _mapper = mapper;
            _imageExtensionRepository = imageExtensionRepository;
            _imageExtensionBusinessRules = imageExtensionBusinessRules;
        }

        public async Task<GetByIdImageExtensionResponse> Handle(GetByIdImageExtensionQuery request, CancellationToken cancellationToken)
        {
            ImageExtension? imageExtension = await _imageExtensionRepository.GetAsync(predicate: ie => ie.Id == request.Id, cancellationToken: cancellationToken);
            await _imageExtensionBusinessRules.ImageExtensionShouldExistWhenSelected(imageExtension);

            GetByIdImageExtensionResponse response = _mapper.Map<GetByIdImageExtensionResponse>(imageExtension);
            return response;
        }
    }
}