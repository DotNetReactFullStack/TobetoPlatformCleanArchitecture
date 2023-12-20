using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Priority).HasColumnName("Priority");
        builder.Property(e => e.Visibility).HasColumnName("Visibility");
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.NumberOfQuestions).HasColumnName("NumberOfQuestions");
        builder.Property(e => e.StartingTime).HasColumnName("StartingTime");
        builder.Property(e => e.EndingTime).HasColumnName("EndingTime");
        builder.Property(e => e.IsActive).HasColumnName("IsActive");
        builder.Property(e => e.Duration).HasColumnName("Duration");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}