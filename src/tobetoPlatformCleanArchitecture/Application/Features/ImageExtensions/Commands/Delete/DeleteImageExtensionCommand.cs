using Application.Features.ImageExtensions.Constants;
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

namespace Application.Features.ImageExtensions.Commands.Delete;

public class DeleteImageExtensionCommand : IRequest<DeletedImageExtensionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ImageExtensionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetImageExtensions";

    public class DeleteImageExtensionCommandHandler : IRequestHandler<DeleteImageExtensionCommand, DeletedImageExtensionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IImageExtensionRepository _imageExtensionRepository;
        private readonly ImageExtensionBusinessRules _imageExtensionBusinessRules;

        public DeleteImageExtensionCommandHandler(IMapper mapper, IImageExtensionRepository imageExtensionRepository,
                                         ImageExtensionBusinessRules imageExtensionBusinessRules)
        {
            _mapper = mapper;
            _imageExtensionRepository = imageExtensionRepository;
            _imageExtensionBusinessRules = imageExtensionBusinessRules;
        }

        public async Task<DeletedImageExtensionResponse> Handle(DeleteImageExtensionCommand request, CancellationToken cancellationToken)
        {
            ImageExtension? imageExtension = await _imageExtensionRepository.GetAsync(predicate: ie => ie.Id == request.Id, cancellationToken: cancellationToken);
            await _imageExtensionBusinessRules.ImageExtensionShouldExistWhenSelected(imageExtension);

            await _imageExtensionRepository.DeleteAsync(imageExtension!);

            DeletedImageExtensionResponse response = _mapper.Map<DeletedImageExtensionResponse>(imageExtension);
            return response;
        }
    }
}