using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.OrganizationTypeId).HasColumnName("OrganizationTypeId");
        builder.Property(o => o.AddressId).HasColumnName("AddressId");
        builder.Property(o => o.Visibility).HasColumnName("Visibility");
        builder.Property(o => o.Name).HasColumnName("Name");
        builder.Property(o => o.ContactNumber).HasColumnName("ContactNumber");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Organization> getSeeds()
    {
        int id = 0;
        HashSet<Organization> seeds =
            new()
            {
                new Organization { Id = ++id, OrganizationTypeId=1, AddressId=1, Name = "İstanbul Kodluyor", ContactNumber="555-555-5555", Visibility=true },
            };

        return seeds;
    }
}