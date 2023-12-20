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
        builder.Property(lp => lp.Name).HasColumnName("Name");
        builder.Property(lp => lp.Visibility).HasColumnName("Visibility");
        builder.Property(lp => lp.StartingTime).HasColumnName("StartingTime");
        builder.Property(lp => lp.EndingTime).HasColumnName("EndingTime");
        builder.Property(lp => lp.NumberOfLikes).HasColumnName("NumberOfLikes");
        builder.Property(lp => lp.TotalDuration).HasColumnName("TotalDuration");
        builder.Property(lp => lp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lp => lp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lp => lp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lp => !lp.DeletedDate.HasValue);
    }
}