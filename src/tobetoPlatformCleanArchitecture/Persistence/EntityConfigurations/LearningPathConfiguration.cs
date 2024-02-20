using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LearningPathConfiguration : IEntityTypeConfiguration<LearningPath>
{
    public void Configure(EntityTypeBuilder<LearningPath> builder)
    {
        builder.ToTable("LearningPaths").HasKey(lp => lp.Id);

        builder.Property(lp => lp.Id).HasColumnName("Id").IsRequired();
        builder.Property(lp => lp.LearningPathCategoryId).HasColumnName("LearningPathCategoryId");
        builder.Property(lp => lp.Name).HasColumnName("Name");
        builder.Property(lp => lp.Visibility).HasColumnName("Visibility");
        builder.Property(lp => lp.StartingTime).HasColumnName("StartingTime");
        builder.Property(lp => lp.EndingTime).HasColumnName("EndingTime");
        builder.Property(lp => lp.NumberOfLikes).HasColumnName("NumberOfLikes");
        builder.Property(lp => lp.TotalDuration).HasColumnName("TotalDuration");
        builder.Property(lp => lp.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(lp => lp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lp => lp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lp => lp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lp => !lp.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<LearningPath> getSeeds()
    {
        int id = 0;
        HashSet<LearningPath> seeds =
            new()
            {
                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name="Full-Stack Developer - 1B", Visibility=true, StartingTime= new DateTime(2024, 2, 20).AddHours(16).AddMinutes(45), EndingTime= new DateTime(2024, 4, 15).AddHours(18).AddMinutes(00), NumberOfLikes=11, TotalDuration=30, ImageUrl="/assets/images/dotnet-react-full-stack.png"},
            };
        return seeds;
    }
}