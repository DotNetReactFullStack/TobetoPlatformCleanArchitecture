using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RecourseStepConfiguration : IEntityTypeConfiguration<RecourseStep>
{
    public void Configure(EntityTypeBuilder<RecourseStep> builder)
    {
        builder.ToTable("RecourseSteps").HasKey(rs => rs.Id);

        builder.Property(rs => rs.Id).HasColumnName("Id").IsRequired();
        builder.Property(rs => rs.Name).HasColumnName("Name");
        builder.Property(rs => rs.Priority).HasColumnName("Priority");
        builder.Property(rs => rs.Visibility).HasColumnName("Visibility");
        builder.Property(rs => rs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rs => rs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rs => rs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rs => !rs.DeletedDate.HasValue);
    }
}