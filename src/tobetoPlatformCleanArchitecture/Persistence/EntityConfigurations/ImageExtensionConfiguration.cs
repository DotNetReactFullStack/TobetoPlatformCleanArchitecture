using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ImageExtensionConfiguration : IEntityTypeConfiguration<ImageExtension>
{
    public void Configure(EntityTypeBuilder<ImageExtension> builder)
    {
        builder.ToTable("ImageExtensions").HasKey(ie => ie.Id);

        builder.Property(ie => ie.Id).HasColumnName("Id").IsRequired();
        builder.Property(ie => ie.Name).HasColumnName("Name");
        builder.Property(ie => ie.IsActive).HasColumnName("IsActive");
        builder.Property(ie => ie.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ie => ie.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ie => ie.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ie => !ie.DeletedDate.HasValue);
    }
}