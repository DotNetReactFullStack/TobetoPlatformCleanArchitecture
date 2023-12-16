using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class QuestionCategoryConfiguration : IEntityTypeConfiguration<QuestionCategory>
{
    public void Configure(EntityTypeBuilder<QuestionCategory> builder)
    {
        builder.ToTable("QuestionCategories").HasKey(qc => qc.Id);

        builder.Property(qc => qc.Id).HasColumnName("Id").IsRequired();
        builder.Property(qc => qc.Name).HasColumnName("Name");
        builder.Property(qc => qc.Priority).HasColumnName("Priority");
        builder.Property(qc => qc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(qc => qc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(qc => qc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(qc => !qc.DeletedDate.HasValue);
    }
}