using Application.Features.Images.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Images.Rules;

public class ImageBusinessRules : BaseBusinessRules
{
    private readonly IImageRepository _imageRepository;

    public ImageBusinessRules(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public Task ImageShouldExistWhenSelected(Image? image)
    {
        if (image == null)
            throw new BusinessException(ImagesBusinessMessages.ImageNotExists);
        return Task.CompletedTask;
    }

    public async Task ImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Image? image = await _imageRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ImageShouldExistWhenSelected(image);
    }
}