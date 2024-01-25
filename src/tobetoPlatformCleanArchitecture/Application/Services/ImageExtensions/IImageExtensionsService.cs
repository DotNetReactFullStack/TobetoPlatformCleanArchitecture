using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ImageExtensions;

public interface IImageExtensionsService
{
    Task<ImageExtension?> GetAsync(
        Expression<Func<ImageExtension, bool>> predicate,
        Func<IQueryable<ImageExtension>, IIncludableQueryable<ImageExtension, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ImageExtension>?> GetListAsync(
        Expression<Func<ImageExtension, bool>>? predicate = null,
        Func<IQueryable<ImageExtension>, IOrderedQueryable<ImageExtension>>? orderBy = null,
        Func<IQueryable<ImageExtension>, IIncludableQueryable<ImageExtension, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ImageExtension> AddAsync(ImageExtension imageExtension);
    Task<ImageExtension> UpdateAsync(ImageExtension imageExtension);
    Task<ImageExtension> DeleteAsync(ImageExtension imageExtension, bool permanent = false);
}
