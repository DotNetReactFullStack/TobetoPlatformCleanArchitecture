using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountForeignLanguageMetadataConfiguration : IEntityTypeConfiguration<AccountForeignLanguageMetadata>
{
    public void Configure(EntityTypeBuilder<AccountForeignLanguageMetadata> builder)
    {
        builder.ToTable("AccountForeignLanguageMetadatas").HasKey(aflm => aflm.Id);

        builder.Property(aflm => aflm.Id).HasColumnName("Id").IsRequired();
        builder.Property(aflm => aflm.AccountId).HasColumnName("AccountId");
        builder.Property(aflm => aflm.ForeignLanguageId).HasColumnName("ForeignLanguageId");
        builder.Property(aflm => aflm.ForeignLanguageLevelId).HasColumnName("ForeignLanguageLevelId");
        builder.Property(aflm => aflm.Priority).HasColumnName("Priority");
        builder.Property(aflm => aflm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aflm => aflm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aflm => aflm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(aflm => !aflm.DeletedDate.HasValue);
    }
}