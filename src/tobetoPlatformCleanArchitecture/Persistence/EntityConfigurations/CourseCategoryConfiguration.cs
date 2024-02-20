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

        builder.HasData(getSeeds());
    }

    private HashSet<CourseCategory> getSeeds()
    {
        int id = 0;
        HashSet<CourseCategory> seeds =
            new()
            {
                new CourseCategory { Id = ++id, Name = "Yazýlým Geliþtirme", Priority=1 , Visibility = true},
                new CourseCategory { Id = ++id, Name = "Kiþisel Geliþim", Priority=1 , Visibility = true},
                new CourseCategory { Id = ++id, Name = "Ýþletme", Priority=1 , Visibility = true},
            };
        return seeds;
    }
}

