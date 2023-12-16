using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AnnouncementTypeConfiguration : IEntityTypeConfiguration<AnnouncementType>
{
    public void Configure(EntityTypeBuilder<AnnouncementType> builder)
    {
        builder.ToTable("AnnouncementTypes").HasKey(at => at.Id);

        builder.Property(at => at.Id).HasColumnName("Id").IsRequired();
        builder.Property(at => at.Name).HasColumnName("Name");
        builder.Property(at => at.Priority).HasColumnName("Priority");
        builder.Property(at => at.Visibility).HasColumnName("Visibility");
        builder.Property(at => at.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(at => at.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(at => at.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(at => !at.DeletedDate.HasValue);
    }
}