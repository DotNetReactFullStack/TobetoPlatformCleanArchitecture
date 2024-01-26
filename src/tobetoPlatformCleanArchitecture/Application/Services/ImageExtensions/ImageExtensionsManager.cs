using Application.Features.ImageExtensions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ImageExtensions;

public class ImageExtensionsManager : IImageExtensionsService
{
    private readonly IImageExtensionRepository _imageExtensionRepository;
    private readonly ImageExtensionBusinessRules _imageExtensionBusinessRules;

    public ImageExtensionsManager(IImageExtensionRepository imageExtensionRepository, ImageExtensionBusinessRules imageExtensionBusinessRules)
    {
        _imageExtensionRepository = imageExtensionRepository;
        _imageExtensionBusinessRules = imageExtensionBusinessRules;
    }

    public async Task<ImageExtension?> GetAsync(
        Expression<Func<ImageExtension, bool>> predicate,
        Func<IQueryable<ImageExtension>, IIncludableQueryable<ImageExtension, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ImageExtension? imageExtension = await _imageExtensionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return imageExtension;
    }

    public async Task<IPaginate<ImageExtension>?> GetListAsync(
        Expression<Func<ImageExtension, bool>>? predicate = null,
        Func<IQueryable<ImageExtension>, IOrderedQueryable<ImageExtension>>? orderBy = null,
        Func<IQueryable<ImageExtension>, IIncludableQueryable<ImageExtension, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ImageExtension> imageExtensionList = await _imageExtensionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return imageExtensionList;
    }

    public async Task<ImageExtension> AddAsync(ImageExtension imageExtension)
    {
        ImageExtension addedImageExtension = await _imageExtensionRepository.AddAsync(imageExtension);

        return addedImageExtension;
    }

    public async Task<ImageExtension> UpdateAsync(ImageExtension imageExtension)
    {
        ImageExtension updatedImageExtension = await _imageExtensionRepository.UpdateAsync(imageExtension);

        return updatedImageExtension;
    }

    public async Task<ImageExtension> DeleteAsync(ImageExtension imageExtension, bool permanent = false)
    {
        ImageExtension deletedImageExtension = await _imageExtensionRepository.DeleteAsync(imageExtension);

        return deletedImageExtension;
    }
}
