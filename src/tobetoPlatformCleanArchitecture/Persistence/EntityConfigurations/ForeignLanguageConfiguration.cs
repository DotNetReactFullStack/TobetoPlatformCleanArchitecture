using Core.Security.Entities;
using Core.Security.Hashing;
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

        builder.HasData(getSeeds());
    }

    private HashSet<ForeignLanguage> getSeeds()
    {
        int id = 0;
        HashSet<ForeignLanguage> seeds =
            new()
            {
                new ForeignLanguage { Id = ++id, Name = "Türkçe", Priority= 1, Visibility=true },
                new ForeignLanguage { Id = ++id, Name = "İngilizce", Priority= 1, Visibility=true },
                new ForeignLanguage { Id = ++id, Name = "Almanca", Priority= 1, Visibility=true },
                new ForeignLanguage { Id = ++id, Name = "Japonca", Priority= 1, Visibility=true },
                new ForeignLanguage { Id = ++id, Name = "Fransızca", Priority= 1, Visibility=true },
            };

        return seeds;
    }
}