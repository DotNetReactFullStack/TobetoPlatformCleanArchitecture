using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.AccountId).HasColumnName("AccountId");
        builder.Property(e => e.CityId).HasColumnName("CityId");
        builder.Property(e => e.CompanyName).HasColumnName("CompanyName");
        builder.Property(e => e.JobTitle).HasColumnName("JobTitle");
        builder.Property(e => e.Industry).HasColumnName("Industry");
        builder.Property(e => e.StartingDate).HasColumnName("StartingDate");
        builder.Property(e => e.EndingDate).HasColumnName("EndingDate");
        builder.Property(e => e.IsCurrentlyWorking).HasColumnName("IsCurrentlyWorking");
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.IsActive).HasColumnName("IsActive");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}