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
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "HTML 5", TotalDuration = 70, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 3, Name= "Proje Aþamalarý", TotalDuration = 1, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 3, Name= "Kampüs Buluþmalarý", TotalDuration = 1, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "Java", TotalDuration = 1080, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "Angular", TotalDuration = 150, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "Flutter", TotalDuration = 400, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 1, Name= "Yemek Sipariþi Uygulamasý", TotalDuration = 720, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 2, Name= "C# & .NET Mülakat Part-1", TotalDuration = 8, Priority= 1, IsActive= true },
                    new Course { Id = ++id, CourseCategoryId= 2, Name= "C# & .NET Mülakat Part-2", TotalDuration = 29, Priority= 1, IsActive= true },
            };
        return seeds;
    }
}

