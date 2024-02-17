using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountCapabilityConfiguration : IEntityTypeConfiguration<AccountCapability>
{
    public void Configure(EntityTypeBuilder<AccountCapability> builder)
    {
        builder.ToTable("AccountCapabilities").HasKey(ac => ac.Id);

        builder.Property(ac => ac.Id).HasColumnName("Id").IsRequired();
        builder.Property(ac => ac.AccountId).HasColumnName("AccountId");
        builder.Property(ac => ac.CapabilityId).HasColumnName("CapabilityId");
        builder.Property(ac => ac.Priority).HasColumnName("Priority");
        builder.Property(ac => ac.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ac => ac.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ac => ac.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ac => !ac.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }
    private HashSet<AccountCapability> getSeeds()
    {
        int id = 0;
        HashSet<AccountCapability> seeds =
            new()
            {
                new AccountCapability { Id = ++id, AccountId = 1, CapabilityId=9, Priority= 1 },
                new AccountCapability { Id = ++id, AccountId = 1, CapabilityId=10, Priority= 2 },
                new AccountCapability { Id = ++id, AccountId = 1, CapabilityId=3, Priority= 3 },
            };

        return seeds;
    }

}