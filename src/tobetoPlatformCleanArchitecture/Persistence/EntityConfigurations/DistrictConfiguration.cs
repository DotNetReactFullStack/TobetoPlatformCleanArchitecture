using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.CityId).HasColumnName("CityId");
        builder.Property(d => d.Name).HasColumnName("Name");
        builder.Property(d => d.Priority).HasColumnName("Priority");
        builder.Property(d => d.Visibility).HasColumnName("Visibility");
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<District> getSeeds()
    {
        int id = 0;
        int cityId = 0;
        HashSet<District> seeds =
            new()
            {
                new District { Id = ++id, CityId=++cityId, Name = "İlçe", Priority= 1, Visibility=true},
                //__District________________________ istanbul, bursa, ankara
                new District { Id = ++id, CityId=++cityId, Name = "Kadiköy", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Bakırköy", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Tuzla", Priority= 3, Visibility=true },
                                  
                new District { Id = ++id, CityId=++cityId, Name = "Osmangazi", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Nilüfer", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "İnegöl", Priority= 3, Visibility=true },
                                  
                new District { Id = ++id, CityId=++cityId, Name = "Çankaya", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Etimesgut", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Yenimahalle", Priority= 3, Visibility=true },
                    
                //__District________________________ londra, liverpool, Manchester__________________________
                new District { Id = ++id, CityId=++cityId, Name = "Chelsea", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Kensington", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Fulham", Priority= 3, Visibility=true },
                    
                new District { Id = ++id, CityId=++cityId, Name = "Ropewalks", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Chinatown", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Lark Lane", Priority= 3, Visibility=true },
                    
                new District { Id = ++id, CityId=++cityId, Name = "Trafford", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Tameside", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Bolton", Priority= 3, Visibility=true },
                    
                 //_District_________________________ roma, floransa, torino________________________________
                new District { Id = ++id, CityId=++cityId, Name = "Pomezia", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Anzio", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Fiumicino", Priority= 3, Visibility=true },
                    
                new District { Id = ++id, CityId=++cityId, Name = "Scandicci", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Empoli", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Signa", Priority= 3, Visibility=true },
                    
                new District { Id = ++id, CityId=++cityId, Name = "Moncalieri", Priority= 1, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Rivoli", Priority= 2, Visibility=true },
                new District { Id = ++id, CityId=cityId, Name = "Chieri", Priority= 3, Visibility=true },
            };

        return seeds;
    }

}