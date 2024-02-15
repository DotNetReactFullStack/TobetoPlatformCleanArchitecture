using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GraduationStatusConfiguration : IEntityTypeConfiguration<GraduationStatus>
{
    public void Configure(EntityTypeBuilder<GraduationStatus> builder)
    {
        builder.ToTable("GraduationStatuses").HasKey(gs => gs.Id);

        builder.Property(gs => gs.Id).HasColumnName("Id").IsRequired();
        builder.Property(gs => gs.Name).HasColumnName("Name");
        builder.Property(gs => gs.Priority).HasColumnName("Priority");
        builder.Property(gs => gs.Visibility).HasColumnName("Visibility");
        builder.Property(gs => gs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gs => gs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gs => gs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gs => !gs.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<GraduationStatus> getSeeds()
    {
        int id = 0;
        HashSet<GraduationStatus> seeds =
            new()
            {
                new GraduationStatus { Id = ++id, Name = "Lisans", Priority= 1, Visibility=true },
                new GraduationStatus { Id = ++id, Name = "Ön Lisans", Priority= 1, Visibility=true },
                new GraduationStatus { Id = ++id, Name = "Yüksek Lisans", Priority= 1, Visibility=true },
                new GraduationStatus { Id = ++id, Name = "Doktora", Priority= 1, Visibility=true }
            };
        return seeds;
    }
}