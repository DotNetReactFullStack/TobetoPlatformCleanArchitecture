using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId");
        builder.Property(a => a.NationalIdentificationNumber).HasColumnName("NationalIdentificationNumber");
        builder.Property(a => a.AboutMe).HasColumnName("AboutMe");
        builder.Property(a => a.BirthDate).HasColumnName("BirthDate");
        builder.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(a => a.ProfilePhotoPath).HasColumnName("ProfilePhotoPath");
        builder.Property(a => a.ShareProfile).HasColumnName("ShareProfile");
        builder.Property(a => a.ProfileLinkUrl).HasColumnName("ProfileLinkUrl");
        builder.Property(a => a.IsActive).HasColumnName("IsActive");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Account> getSeeds()
    {
        int id = 0;
        HashSet<Account> seeds =
            new()
            {
                new Account { Id = ++id, UserId=1, NationalIdentificationNumber="11111111110", AboutMe="About me", BirthDate=new DateTime(1990, 1, 2), PhoneNumber="555 555 55 55", ShareProfile=false, ProfileLinkUrl="/", IsActive=true  },
            };

        return seeds;
    }
}