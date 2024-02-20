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
        builder.Property(alp => alp.PercentComplete).HasColumnName("PercentComplete");
        builder.Property(alp => alp.IsContinue).HasColumnName("IsContinue");
        builder.Property(alp => alp.IsComplete).HasColumnName("IsComplete");
        builder.Property(alp => alp.IsLiked).HasColumnName("IsLiked");
        builder.Property(alp => alp.IsSaved).HasColumnName("IsSaved");
        builder.Property(alp => alp.IsActive).HasColumnName("IsActive");
        builder.Property(alp => alp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(alp => alp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(alp => alp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(alp => !alp.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<AccountLearningPath> getSeeds()
    {
        int id = 0;
        HashSet<AccountLearningPath> seeds =
            new()
            {
                    new AccountLearningPath { Id = ++id, AccountId=1, LearningPathId=1, TotalNumberOfPoints=30, PercentComplete=35, IsContinue=true, IsComplete= false, IsLiked=true, IsSaved=true, IsActive=true},
            };
        return seeds;
    }
}