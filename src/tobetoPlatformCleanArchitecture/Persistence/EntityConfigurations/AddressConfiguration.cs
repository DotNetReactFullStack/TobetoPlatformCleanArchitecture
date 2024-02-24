using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AccountId).HasColumnName("AccountId");
        builder.Property(a => a.CountryId).HasColumnName("CountryId");
        builder.Property(a => a.CityId).HasColumnName("CityId");
        builder.Property(a => a.DistrictId).HasColumnName("DistrictId");
        builder.Property(a => a.AddressDetail).HasColumnName("AddressDetail");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder
            .HasOne(a => a.Country)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder
            .HasOne(a => a.District)
            .WithMany(d => d.Addresses)
            .HasForeignKey(a => a.DistrictId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Address> getSeeds()
    {
        int id = 0;
        HashSet<Address> seeds =
            new()
            {
                new Address { Id = ++id, AccountId=1, CountryId=1, CityId=1, DistrictId=1, AddressDetail = "Organizasyon adresi..." },
            };

        return seeds;
    }
}