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
                new College { Id = ++id, Name = "Boðaziçi Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Ýstanbul Teknik Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Orta Doðu Teknik Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Bursa Uludað Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Hacettepe Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Ýstanbul Üniversitesi", Visibility=true },
                new College { Id = ++id, Name = "Gazi Üniversitesi", Visibility=true }
            };
        return seeds;
    }
}