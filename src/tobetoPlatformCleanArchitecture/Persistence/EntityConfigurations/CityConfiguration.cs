using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CountryId).HasColumnName("CountryId");
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.Priority).HasColumnName("Priority");
        builder.Property(c => c.Visibility).HasColumnName("Visibility");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<City> getSeeds()
    {
        int id = 0;
        int countryId = 0;
        HashSet<City> seeds =
            new()
            {
                new City { Id = ++id, CountryId=++countryId, Name = "İl", Priority= 1, Visibility=true },

                new City { Id = ++id, CountryId=++countryId, Name = "İstanbul", Priority= 1, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Bursa", Priority= 2, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Ankara", Priority= 3, Visibility=true },
                
                new City { Id = ++id, CountryId=++countryId, Name = "Londra", Priority= 1, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Liverpool", Priority= 2, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Manchester", Priority= 3, Visibility=true },
                
                new City { Id = ++id, CountryId=++countryId, Name = "Roma", Priority= 1, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Floransa", Priority= 2, Visibility=true },
                new City { Id = ++id, CountryId=countryId, Name = "Torino", Priority= 3, Visibility=true },
            };

        return seeds;
    }
}