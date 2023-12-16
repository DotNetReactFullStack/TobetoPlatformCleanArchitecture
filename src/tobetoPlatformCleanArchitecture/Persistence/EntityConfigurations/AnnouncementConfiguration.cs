using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AnnouncementTypeId).HasColumnName("AnnouncementTypeId");
        builder.Property(a => a.OrganizationId).HasColumnName("OrganizationId");
        builder.Property(a => a.Priority).HasColumnName("Priority");
        builder.Property(a => a.Visibility).HasColumnName("Visibility");
        builder.Property(a => a.Name).HasColumnName("Name");
        builder.Property(a => a.Content).HasColumnName("Content");
        builder.Property(a => a.PublishedDate).HasColumnName("PublishedDate");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}