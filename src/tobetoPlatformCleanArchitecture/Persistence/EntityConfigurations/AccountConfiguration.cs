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
        builder.Property(a => a.AddressId).HasColumnName("AddressId");
        builder.Property(a => a.NationalIdentificationNumber).HasColumnName("NationalIdentificationNumber");
        builder.Property(a => a.BirthDate).HasColumnName("BirthDate");
        builder.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(a => a.ProfilePhotoPath).HasColumnName("ProfilePhotoPath");
        builder.Property(a => a.IsActive).HasColumnName("IsActive");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}