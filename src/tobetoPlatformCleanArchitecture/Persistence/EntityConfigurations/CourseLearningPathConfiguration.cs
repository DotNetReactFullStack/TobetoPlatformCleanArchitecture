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

        builder.HasData(getSeeds());
    }

    private HashSet<CourseLearningPath> getSeeds()
    {
        int id = 0;
        HashSet<CourseLearningPath> seeds =
            new()
            {
                    new CourseLearningPath { Id = ++id, CourseId=1, LearningPathId=1, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=4, LearningPathId=1, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=5, LearningPathId=2, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=6, LearningPathId=2, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=7, LearningPathId=3, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=8, LearningPathId=3, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=9, LearningPathId=4, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=10, LearningPathId=4, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=11, LearningPathId=5, Visibility=true},
                    new CourseLearningPath { Id = ++id, CourseId=12, LearningPathId=5, Visibility=true},
            };
        return seeds;
    }
}