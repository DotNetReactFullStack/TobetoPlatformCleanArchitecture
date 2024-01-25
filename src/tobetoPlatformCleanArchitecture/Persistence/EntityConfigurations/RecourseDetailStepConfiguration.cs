using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RecourseDetailStepConfiguration : IEntityTypeConfiguration<RecourseDetailStep>
{
    public void Configure(EntityTypeBuilder<RecourseDetailStep> builder)
    {
        builder.ToTable("RecourseDetailSteps").HasKey(rds => rds.Id);

        builder.Property(rds => rds.Id).HasColumnName("Id").IsRequired();
        builder.Property(rds => rds.Name).HasColumnName("Name");
        builder.Property(rds => rds.Priority).HasColumnName("Priority");
        builder.Property(rds => rds.Visibility).HasColumnName("Visibility");
        builder.Property(rds => rds.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rds => rds.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rds => rds.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rds => !rds.DeletedDate.HasValue);
    }
}