using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Images;

public interface IImagesService
{
    Task<Image?> GetAsync(
        Expression<Func<Image, bool>> predicate,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Image>?> GetListAsync(
        Expression<Func<Image, bool>>? predicate = null,
        Func<IQueryable<Image>, IOrderedQueryable<Image>>? orderBy = null,
        Func<IQueryable<Image>, IIncludableQueryable<Image, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Image> AddAsync(Image image);
    Task<Image> UpdateAsync(Image image);
    Task<Image> DeleteAsync(Image image, bool permanent = false);
}
