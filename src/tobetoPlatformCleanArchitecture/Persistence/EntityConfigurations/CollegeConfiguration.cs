using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CollegeConfiguration : IEntityTypeConfiguration<College>
{
    public void Configure(EntityTypeBuilder<College> builder)
    {
        builder.ToTable("Colleges").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.Visibility).HasColumnName("Visibility");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<College> getSeeds()
    {
        int id = 0;
        HashSet<College> seeds =
            new()
            {
                new College { Id = ++id, Name = "Anadolu Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Beykoz Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Düzce Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "İstanbul Teknik Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Orta Doğu Teknik Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Bursa Uludağ Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Boğaziçi Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Hacettepe Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "İstanbul Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Gazi Üniversitesi", Visibility=true },
            };
        return seeds;
    }
}