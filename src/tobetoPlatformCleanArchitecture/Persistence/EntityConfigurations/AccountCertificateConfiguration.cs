using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountCertificateConfiguration : IEntityTypeConfiguration<AccountCertificate>
{
    public void Configure(EntityTypeBuilder<AccountCertificate> builder)
    {
        builder.ToTable("AccountCertificates").HasKey(ac => ac.Id);

        builder.Property(ac => ac.Id).HasColumnName("Id").IsRequired();
        builder.Property(ac => ac.AccountId).HasColumnName("AccountId");
        builder.Property(ac => ac.CertificateId).HasColumnName("CertificateId");
        builder.Property(ac => ac.Priority).HasColumnName("Priority");
        builder.Property(ac => ac.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ac => ac.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ac => ac.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ac => !ac.DeletedDate.HasValue);
    }
}