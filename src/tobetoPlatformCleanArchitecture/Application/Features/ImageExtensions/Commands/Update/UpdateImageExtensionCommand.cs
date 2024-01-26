using Application.Features.ImageExtensions.Constants;
using Application.Features.ImageExtensions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ImageExtensions.Constants.ImageExtensionsOperationClaims;

namespace Application.Features.ImageExtensions.Commands.Update;

public class UpdateImageExtensionCommand : IRequest<UpdatedImageExtensionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ImageExtensionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetImageExtensions";

    public class UpdateImageExtensionCommandHandler : IRequestHandler<UpdateImageExtensionCommand, UpdatedImageExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageExtensionRepository _imageExtensionRepository;
        private readonly ImageExtensionBusinessRules _imageExtensionBusinessRules;

        public UpdateImageExtensionCommandHandler(IMapper mapper, IImageExtensionRepository imageExtensionRepository,
                                         ImageExtensionBusinessRules imageExtensionBusinessRules)
        {
            _mapper = mapper;
            _imageExtensionRepository = imageExtensionRepository;
            _imageExtensionBusinessRules = imageExtensionBusinessRules;
        }

        public async Task<UpdatedImageExtensionResponse> Handle(UpdateImageExtensionCommand request, CancellationToken cancellationToken)
        {
            ImageExtension? imageExtension = await _imageExtensionRepository.GetAsync(predicate: ie => ie.Id == request.Id, cancellationToken: cancellationToken);
            await _imageExtensionBusinessRules.ImageExtensionShouldExistWhenSelected(imageExtension);
            imageExtension = _mapper.Map(request, imageExtension);

            await _imageExtensionRepository.UpdateAsync(imageExtension!);

            UpdatedImageExtensionResponse response = _mapper.Map<UpdatedImageExtensionResponse>(imageExtension);
            return response;
        }
    }
}