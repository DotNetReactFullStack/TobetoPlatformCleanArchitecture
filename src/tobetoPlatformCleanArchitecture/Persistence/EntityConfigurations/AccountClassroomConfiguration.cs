using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountClassroomConfiguration : IEntityTypeConfiguration<AccountClassroom>
{
    public void Configure(EntityTypeBuilder<AccountClassroom> builder)
    {
        builder.ToTable("AccountClassrooms").HasKey(ac => ac.Id);

        builder.Property(ac => ac.Id).HasColumnName("Id").IsRequired();
        builder.Property(ac => ac.AccountId).HasColumnName("AccountId");
        builder.Property(ac => ac.ClassroomId).HasColumnName("ClassroomId");
        builder.Property(ac => ac.IsActive).HasColumnName("IsActive");
        builder.Property(ac => ac.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ac => ac.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ac => ac.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ac => !ac.DeletedDate.HasValue);
    }
}