using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountCollageMetadataConfiguration : IEntityTypeConfiguration<AccountCollageMetadata>
{
    public void Configure(EntityTypeBuilder<AccountCollageMetadata> builder)
    {
        builder.ToTable("AccountCollageMetadatas").HasKey(acm => acm.Id);

        builder.Property(acm => acm.Id).HasColumnName("Id").IsRequired();
        builder.Property(acm => acm.AccountId).HasColumnName("AccountId");
        builder.Property(acm => acm.GraduationStatusId).HasColumnName("GraduationStatusId");
        builder.Property(acm => acm.CollegeId).HasColumnName("CollegeId");
        builder.Property(acm => acm.EducationProgramId).HasColumnName("EducationProgramId");
        builder.Property(acm => acm.Visibility).HasColumnName("Visibility");
        builder.Property(acm => acm.StartingYear).HasColumnName("StartingYear");
        builder.Property(acm => acm.GraduationYear).HasColumnName("GraduationYear");
        builder.Property(acm => acm.ProgramOnGoing).HasColumnName("ProgramOnGoing");
        builder.Property(acm => acm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(acm => acm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(acm => acm.DeletedDate).HasColumnName("DeletedDate");

        //Relationships
        builder
            .HasOne(a => a.EducationProgram)
            .WithMany(e => e.AccountCollageMetadatas)
            .HasForeignKey(a => a.EducationProgramId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasQueryFilter(acm => !acm.DeletedDate.HasValue);
    }
}