using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AnnouncementTypes;

public interface IAnnouncementTypesService
{
    Task<AnnouncementType?> GetAsync(
        Expression<Func<AnnouncementType, bool>> predicate,
        Func<IQueryable<AnnouncementType>, IIncludableQueryable<AnnouncementType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AnnouncementType>?> GetListAsync(
        Expression<Func<AnnouncementType, bool>>? predicate = null,
        Func<IQueryable<AnnouncementType>, IOrderedQueryable<AnnouncementType>>? orderBy = null,
        Func<IQueryable<AnnouncementType>, IIncludableQueryable<AnnouncementType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AnnouncementType> AddAsync(AnnouncementType announcementType);
    Task<AnnouncementType> UpdateAsync(AnnouncementType announcementType);
    Task<AnnouncementType> DeleteAsync(AnnouncementType announcementType, bool permanent = false);
}
