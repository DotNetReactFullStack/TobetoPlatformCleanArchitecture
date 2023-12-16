using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
{
    public void Configure(EntityTypeBuilder<ExamQuestion> builder)
    {
        builder.ToTable("ExamQuestions").HasKey(eq => eq.Id);

        builder.Property(eq => eq.Id).HasColumnName("Id").IsRequired();
        builder.Property(eq => eq.ExamId).HasColumnName("ExamId");
        builder.Property(eq => eq.QuestionId).HasColumnName("QuestionId");
        builder.Property(eq => eq.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(eq => eq.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(eq => eq.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(eq => !eq.DeletedDate.HasValue);
    }
}