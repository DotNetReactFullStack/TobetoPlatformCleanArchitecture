using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseLearningPathConfiguration : IEntityTypeConfiguration<CourseLearningPath>
{
    public void Configure(EntityTypeBuilder<CourseLearningPath> builder)
    {
        builder.ToTable("CourseLearningPaths").HasKey(clp => clp.Id);

        builder.Property(clp => clp.Id).HasColumnName("Id").IsRequired();
        builder.Property(clp => clp.CourseId).HasColumnName("CourseId");
        builder.Property(clp => clp.LearningPathId).HasColumnName("LearningPathId");
        builder.Property(clp => clp.Visibility).HasColumnName("Visibility");
        builder.Property(clp => clp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(clp => clp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(clp => clp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(clp => !clp.DeletedDate.HasValue);
    }
}