using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrganizationTypeConfiguration : IEntityTypeConfiguration<OrganizationType>
{
    public void Configure(EntityTypeBuilder<OrganizationType> builder)
    {
        builder.ToTable("OrganizationTypes").HasKey(ot => ot.Id);

        builder.Property(ot => ot.Id).HasColumnName("Id").IsRequired();
        builder.Property(ot => ot.Name).HasColumnName("Name");
        builder.Property(ot => ot.Priority).HasColumnName("Priority");
        builder.Property(ot => ot.Visibility).HasColumnName("Visibility");
        builder.Property(ot => ot.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ot => ot.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ot => ot.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ot => !ot.DeletedDate.HasValue);
    }
}