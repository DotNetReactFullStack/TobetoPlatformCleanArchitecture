using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.ToTable("CourseCategories").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.Name).HasColumnName("Name");
        builder.Property(cc => cc.Priority).HasColumnName("Priority");
        builder.Property(cc => cc.Visibility).HasColumnName("Visibility");
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);
    }
}