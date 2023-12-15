using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ForeignLanguageConfiguration : IEntityTypeConfiguration<ForeignLanguage>
{
    public void Configure(EntityTypeBuilder<ForeignLanguage> builder)
    {
        builder.ToTable("ForeignLanguages").HasKey(fl => fl.Id);

        builder.Property(fl => fl.Id).HasColumnName("Id").IsRequired();
        builder.Property(fl => fl.Name).HasColumnName("Name");
        builder.Property(fl => fl.Priority).HasColumnName("Priority");
        builder.Property(fl => fl.Visibility).HasColumnName("Visibility");
        builder.Property(fl => fl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fl => fl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fl => fl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(fl => !fl.DeletedDate.HasValue);
    }
}