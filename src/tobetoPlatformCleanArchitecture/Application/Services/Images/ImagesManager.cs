using Application.Features.Images.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Images;

public class ImagesManager : IImagesService
{
    private readonly IImageRepository _imageRepository;
    private readonly ImageBusinessRules _imageBusinessRules;

    public ImagesManager(IImageRepository imageRepository, ImageBusinessRules imageBusinessRules)
    {
        _imageRepository = imageRepository;
        _imageBusinessRules = imageBusinessRules;
    }

    public async Task<Image?> GetAsync(
        Expression<Func<Image, bool>> predicate,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Image? image = await _imageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return image;
    }

    public async Task<IPaginate<Image>?> GetListAsync(
        Expression<Func<Image, bool>>? predicate = null,
        Func<IQueryable<Image>, IOrderedQueryable<Image>>? orderBy = null,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Image> imageList = await _imageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return imageList;
    }

    public async Task<Image> AddAsync(Image image)
    {
        Image addedImage = await _imageRepository.AddAsync(image);

        return addedImage;
    }

    public async Task<Image> UpdateAsync(Image image)
    {
        Image updatedImage = await _imageRepository.UpdateAsync(image);

        return updatedImage;
    }

    public async Task<Image> DeleteAsync(Image image, bool permanent = false)
    {
        Image deletedImage = await _imageRepository.DeleteAsync(image);

        return deletedImage;
    }
}
