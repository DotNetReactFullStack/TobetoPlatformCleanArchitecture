using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ForeignLanguageLevelConfiguration : IEntityTypeConfiguration<ForeignLanguageLevel>
{
    public void Configure(EntityTypeBuilder<ForeignLanguageLevel> builder)
    {
        builder.ToTable("ForeignLanguageLevels").HasKey(fll => fll.Id);

        builder.Property(fll => fll.Id).HasColumnName("Id").IsRequired();
        builder.Property(fll => fll.Name).HasColumnName("Name");
        builder.Property(fll => fll.Priority).HasColumnName("Priority");
        builder.Property(fll => fll.Visibility).HasColumnName("Visibility");
        builder.Property(fll => fll.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fll => fll.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fll => fll.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(fll => !fll.DeletedDate.HasValue);
    }
}