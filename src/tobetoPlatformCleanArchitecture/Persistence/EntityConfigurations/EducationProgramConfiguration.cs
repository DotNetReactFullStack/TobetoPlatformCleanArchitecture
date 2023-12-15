using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
{
    public void Configure(EntityTypeBuilder<EducationProgram> builder)
    {
        builder.ToTable("EducationPrograms").HasKey(ep => ep.Id);

        builder.Property(ep => ep.Id).HasColumnName("Id").IsRequired();
        builder.Property(ep => ep.CollegeId).HasColumnName("CollegeId");
        builder.Property(ep => ep.Name).HasColumnName("Name");
        builder.Property(ep => ep.Visibility).HasColumnName("Visibility");
        builder.Property(ep => ep.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ep => ep.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ep => ep.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ep => !ep.DeletedDate.HasValue);
    }
}