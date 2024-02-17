using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountSocialMediaPlatformConfiguration : IEntityTypeConfiguration<AccountSocialMediaPlatform>
{
    public void Configure(EntityTypeBuilder<AccountSocialMediaPlatform> builder)
    {
        builder.ToTable("AccountSocialMediaPlatforms").HasKey(asmp => asmp.Id);

        builder.Property(asmp => asmp.Id).HasColumnName("Id").IsRequired();
        builder.Property(asmp => asmp.AccountId).HasColumnName("AccountId");
        builder.Property(asmp => asmp.SocialMediaPlatformId).HasColumnName("SocialMediaPlatformId");
        builder.Property(asmp => asmp.Priority).HasColumnName("Priority");
        builder.Property(asmp => asmp.Link).HasColumnName("Link");
        builder.Property(asmp => asmp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(asmp => asmp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(asmp => asmp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(asmp => !asmp.DeletedDate.HasValue);
        builder.HasData(getSeeds());
    }

    private HashSet<AccountSocialMediaPlatform> getSeeds()
    {
        int id = 0;
        HashSet<AccountSocialMediaPlatform> seeds =
            new()
            {
                new AccountSocialMediaPlatform { Id = ++id, AccountId = 1, SocialMediaPlatformId=1, Priority= 1, Link="https://github.com/DotNetReactFullStack" },
                new AccountSocialMediaPlatform { Id = ++id, AccountId = 1, SocialMediaPlatformId=2, Priority= 2, Link="https://www.linkedin.com/company/github/" },
            };

        return seeds;
    }

}