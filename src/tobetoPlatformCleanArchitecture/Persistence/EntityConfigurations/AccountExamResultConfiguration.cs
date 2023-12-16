using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountExamResultConfiguration : IEntityTypeConfiguration<AccountExamResult>
{
    public void Configure(EntityTypeBuilder<AccountExamResult> builder)
    {
        builder.ToTable("AccountExamResults").HasKey(aer => aer.Id);

        builder.Property(aer => aer.Id).HasColumnName("Id").IsRequired();
        builder.Property(aer => aer.AccountId).HasColumnName("AccountId");
        builder.Property(aer => aer.ExamId).HasColumnName("ExamId");
        builder.Property(aer => aer.Visibility).HasColumnName("Visibility");
        builder.Property(aer => aer.NumberOfRightAnswers).HasColumnName("NumberOfRightAnswers");
        builder.Property(aer => aer.NumberOfWrongAnswers).HasColumnName("NumberOfWrongAnswers");
        builder.Property(aer => aer.NumberOfNullAnswers).HasColumnName("NumberOfNullAnswers");
        builder.Property(aer => aer.Points).HasColumnName("Points");
        builder.Property(aer => aer.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aer => aer.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aer => aer.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(aer => !aer.DeletedDate.HasValue);
    }
}