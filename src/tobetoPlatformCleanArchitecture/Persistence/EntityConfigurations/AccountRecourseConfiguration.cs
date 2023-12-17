using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountRecourseConfiguration : IEntityTypeConfiguration<AccountRecourse>
{
    public void Configure(EntityTypeBuilder<AccountRecourse> builder)
    {
        builder.ToTable("AccountRecourses").HasKey(ar => ar.Id);

        builder.Property(ar => ar.Id).HasColumnName("Id").IsRequired();
        builder.Property(ar => ar.AccountId).HasColumnName("AccountId");
        builder.Property(ar => ar.ApplicationId).HasColumnName("ApplicationId");
        builder.Property(ar => ar.ApplicationStepId).HasColumnName("ApplicationStepId");
        builder.Property(ar => ar.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ar => ar.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ar => ar.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ar => !ar.DeletedDate.HasValue);
    }
}