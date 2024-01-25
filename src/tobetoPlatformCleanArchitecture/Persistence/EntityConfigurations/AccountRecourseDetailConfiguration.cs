using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountRecourseDetailConfiguration : IEntityTypeConfiguration<AccountRecourseDetail>
{
    public void Configure(EntityTypeBuilder<AccountRecourseDetail> builder)
    {
        builder.ToTable("AccountRecourseDetails").HasKey(ard => ard.Id);

        builder.Property(ard => ard.Id).HasColumnName("Id").IsRequired();
        builder.Property(ard => ard.AccountRecourseId).HasColumnName("AccountRecourseId");
        builder.Property(ard => ard.RecourseDetailStepId).HasColumnName("RecourseDetailStepId");
        builder.Property(ard => ard.RecourseDetailId).HasColumnName("RecourseDetailId");
        builder.Property(ard => ard.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ard => ard.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ard => ard.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ard => !ard.DeletedDate.HasValue);
    }
}