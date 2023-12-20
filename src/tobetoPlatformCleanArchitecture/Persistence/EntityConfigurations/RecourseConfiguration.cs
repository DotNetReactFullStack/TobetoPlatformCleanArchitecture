using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RecourseConfiguration : IEntityTypeConfiguration<Recourse>
{
    public void Configure(EntityTypeBuilder<Recourse> builder)
    {
        builder.ToTable("Recourses").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.OrganizationId).HasColumnName("OrganizationId");
        builder.Property(r => r.Priority).HasColumnName("Priority");
        builder.Property(r => r.Visibility).HasColumnName("Visibility");
        builder.Property(r => r.Title).HasColumnName("Title");
        builder.Property(r => r.Content).HasColumnName("Content");
        builder.Property(r => r.IsActive).HasColumnName("IsActive");
        builder.Property(r => r.PublishedDate).HasColumnName("PublishedDate");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}