using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountCollegeMetadataConfiguration : IEntityTypeConfiguration<AccountCollegeMetadata>
{
    public void Configure(EntityTypeBuilder<AccountCollegeMetadata> builder)
    {
        builder.ToTable("AccountCollegeMetadatas").HasKey(acm => acm.Id);

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

        builder
           .HasOne(acm => acm.EducationProgram)
           .WithMany(ep => ep.AccountCollegeMetadatas)
           .HasForeignKey(acm => acm.EducationProgramId)
           .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasQueryFilter(acm => !acm.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<AccountCollegeMetadata> getSeeds()
    {
        int id = 0;
        HashSet<AccountCollegeMetadata> seeds =
            new()
            {
                new AccountCollegeMetadata { Id = ++id, AccountId = 1, GraduationStatusId = 1, CollegeId = 1, EducationProgramId = 1, Visibility = true, StartingYear = new DateTime(2014, 1, 1), GraduationYear = new DateTime(2019, 1, 2), ProgramOnGoing = false},
                new AccountCollegeMetadata { Id = ++id, AccountId = 1, GraduationStatusId = 3, CollegeId = 2, EducationProgramId = 2, Visibility = true, StartingYear = new DateTime(2019, 1, 1), GraduationYear = new DateTime(2021, 1, 2), ProgramOnGoing = false},
                new AccountCollegeMetadata { Id = ++id, AccountId = 1, GraduationStatusId = 4, CollegeId = 3, EducationProgramId = 3, Visibility = true, StartingYear = new DateTime(2021, 1, 1), GraduationYear = null, ProgramOnGoing = true},
            };
        return seeds;
    }
}