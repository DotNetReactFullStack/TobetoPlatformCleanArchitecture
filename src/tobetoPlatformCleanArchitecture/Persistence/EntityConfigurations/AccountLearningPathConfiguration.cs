using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountLearningPathConfiguration : IEntityTypeConfiguration<AccountLearningPath>
{
    public void Configure(EntityTypeBuilder<AccountLearningPath> builder)
    {
        builder.ToTable("AccountLearningPaths").HasKey(alp => alp.Id);

        builder.Property(alp => alp.Id).HasColumnName("Id").IsRequired();
        builder.Property(alp => alp.AccountId).HasColumnName("AccountId");
        builder.Property(alp => alp.LearningPathId).HasColumnName("LearningPathId");
        builder.Property(alp => alp.TotalNumberOfPoints).HasColumnName("TotalNumberOfPoints");
        builder.Property(alp => alp.PercentCompleted).HasColumnName("PercentCompleted");
        builder.Property(alp => alp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(alp => alp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(alp => alp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(alp => !alp.DeletedDate.HasValue);
    }
}