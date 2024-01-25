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

namespace Application.Features.ImageExtensions.Commands.Create;

public class CreateImageExtensionCommand : IRequest<CreatedImageExtensionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ImageExtensionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetImageExtensions";

    public class CreateImageExtensionCommandHandler : IRequestHandler<CreateImageExtensionCommand, CreatedImageExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageExtensionRepository _imageExtensionRepository;
        private readonly ImageExtensionBusinessRules _imageExtensionBusinessRules;

        public CreateImageExtensionCommandHandler(IMapper mapper, IImageExtensionRepository imageExtensionRepository,
                                         ImageExtensionBusinessRules imageExtensionBusinessRules)
        {
            _mapper = mapper;
            _imageExtensionRepository = imageExtensionRepository;
            _imageExtensionBusinessRules = imageExtensionBusinessRules;
        }

        public async Task<CreatedImageExtensionResponse> Handle(CreateImageExtensionCommand request, CancellationToken cancellationToken)
        {
            ImageExtension imageExtension = _mapper.Map<ImageExtension>(request);

            await _imageExtensionRepository.AddAsync(imageExtension);

            CreatedImageExtensionResponse response = _mapper.Map<CreatedImageExtensionResponse>(imageExtension);
            return response;
        }
    }
}