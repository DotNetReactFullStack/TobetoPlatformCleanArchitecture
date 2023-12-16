using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.QuestionId).HasColumnName("QuestionId");
        builder.Property(a => a.AnswerDetail).HasColumnName("AnswerDetail");
        builder.Property(a => a.RightAnswerBool).HasColumnName("RightAnswerBool");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}