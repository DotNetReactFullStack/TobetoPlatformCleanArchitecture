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

        builder.HasData(getSeeds());
    }

    private HashSet<ForeignLanguageLevel> getSeeds()
    {
        int id = 0;
        HashSet<ForeignLanguageLevel> seeds =
            new()
            {
                new ForeignLanguageLevel { Id = ++id, Name = "Temel Seviye (A1, A2)", Priority= 1, Visibility=true },
                new ForeignLanguageLevel { Id = ++id, Name = "Orta Seviye (B1, B2)", Priority= 1, Visibility=true },
                new ForeignLanguageLevel { Id = ++id, Name = "İleri Seviye (C1, C2)", Priority= 1, Visibility=true },
                new ForeignLanguageLevel { Id = ++id, Name = "Anadil", Priority= 1, Visibility=true },
            };

        return seeds;
    }
}