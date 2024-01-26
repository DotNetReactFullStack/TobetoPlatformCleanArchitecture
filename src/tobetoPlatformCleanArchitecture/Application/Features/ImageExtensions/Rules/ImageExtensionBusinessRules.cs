using Application.Features.ImageExtensions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ImageExtensions.Rules;

public class ImageExtensionBusinessRules : BaseBusinessRules
{
    private readonly IImageExtensionRepository _imageExtensionRepository;

    public ImageExtensionBusinessRules(IImageExtensionRepository imageExtensionRepository)
    {
        _imageExtensionRepository = imageExtensionRepository;
    }

    public Task ImageExtensionShouldExistWhenSelected(ImageExtension? imageExtension)
    {
        if (imageExtension == null)
            throw new BusinessException(ImageExtensionsBusinessMessages.ImageExtensionNotExists);
        return Task.CompletedTask;
    }

    public async Task ImageExtensionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ImageExtension? imageExtension = await _imageExtensionRepository.GetAsync(
            predicate: ie => ie.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ImageExtensionShouldExistWhenSelected(imageExtension);
    }
}