using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CourseCategoryId).HasColumnName("CourseCategoryId");
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.TotalDuration).HasColumnName("TotalDuration");
        builder.Property(c => c.Priority).HasColumnName("Priority");
        builder.Property(c => c.IsActive).HasColumnName("IsActive");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Course> getSeeds()
    {
        int id = 0;
        HashSet<Course> seeds =
            new()
            {
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "Yazýlým Geliþtirici Yetiþtirme Kampý", TotalDuration = 50, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "React", TotalDuration = 20, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "TypeScript", TotalDuration = 30, Priority= 1, IsActive= true },
            };
        return seeds;
    }
}

